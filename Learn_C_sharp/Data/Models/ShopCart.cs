using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// корзина
namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent; // для работы с БД

        public ShopCart(AppDBContent appDBContent) // для работы с БД
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItem { get; set; } // список всех элементов внутри корзины

        public static ShopCart GetCart(IServiceProvider services) //работа с корзиной
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // создаем сессию
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CardId") ?? Guid.NewGuid().ToString(); // проверяем идентификатор корзины

            session.SetString("CardId", shopCartId); // добавляем новое значение ключа CardId? фактически проверяем и обновляем сессиию для корзины

            return new ShopCart(context)
            {
                ShopCartId = shopCartId
            };
        }

        public void AddToCart(Car car) // добавляет товар в корзину
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                car = car,
                price = car.priceCar
            });

            appDBContent.SaveChanges();
        }

        // отображает все товары в корзине
        public List<ShopCartItem> getShopItems()
        {// обращаемся к базе и получаем товары которые есть только в текущей сессии (c => c.ShopCartId == ShopCartId)
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }


    }
}
