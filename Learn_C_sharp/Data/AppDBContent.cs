using Shop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data
{
    public class AppDBContent : DbContext // класс который работает с базой данной
    {



        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        // регистрируем таблицы бд которые нам нужны
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
