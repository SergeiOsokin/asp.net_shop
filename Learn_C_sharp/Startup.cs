using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.mocks;
using Shop.Data.Repository;
using System.IO;
using Shop.Data.Models;

namespace Shop
{
    public class Startup
    {
        public static class ConfigurationBinder { };

        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbset.json").Build();//база данных
        }

        public void ConfigureServices(IServiceCollection services) // регистрация модулей и плагинов, 
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddMvc(options => options.EnableEndpointRouting = false);

            // services.AddTransient<IAllCars, MockCars>(); //позволяет объединить интерфейс и класс который реализует этот интерфейс. т.е. это связка 
            services.AddTransient<IAllCars, CarRepository>();// тут уже связываем интерфейс с базой данных, а не берем из файла MockCars

            services.AddTransient<ICarsCategory, CategoryRepository>();// тут уже связываем интерфейс с базой данных, а не берем из файла MockCategory
            //services.AddTransient<ICarsCategory, MockCategory>(); // интерфейс ICarsCategory реализуется в MockCategory
            services.AddTransient<IAllOrders, OrdersRepository>();// тут уже связываем интерфейс с базой данных

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.AddScoped(sp => ShopCart.GetCart(sp)); //если два пользователя зайдут в корзину у каждого будет своя

            services.AddMvc();

            //используем кэш и сессии
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();// страница с ошибкой
            app.UseStatusCodePages(); // коды страниц (404, 500 и т.д.)
            app.UseStaticFiles(); // для использования статичных файлов
            app.UseSession();
            //app.UseMvcWithDefaultRoute();// позволяет автоматически переходить на главную страницу HomeController

            app.UseMvc(routes => {// самостоятельно настраиваем переходы по url и какие контроллеры и функции использовать
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"); //когда url пустой. вызываем контроллер Home а в нем метод Index. {id?} - может быть, а может нет 
                routes.MapRoute(name: "categoryFilter", template: "{Car}/{action}/{category?}", defaults: new {
                    Controller = "Car",
                    action = "List"
                });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("First app");
                });
            });*/
        }
    }
}
