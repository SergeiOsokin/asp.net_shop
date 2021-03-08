using System;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBcontent; // для работы с базой данных
        private readonly ShopCart shopCart; // сама корзина, что в ней есть

        public OrdersRepository(AppDBContent appDBcontent, ShopCart shopCart)
        {
            this.appDBcontent = appDBcontent;
            this.shopCart = shopCart;
        }
             
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now; // устанавливаем время заказа
            appDBcontent.Order.Add(order); // обращаемся в БД к таблице Order и добавляем заказ

            var items = shopCart.listShopItem;// все товары, которые покупает пользователь

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    carId = el.car.id,
                    orderAD = order.id,
                    price = (uint)el.car.priceCar, //(uint) явное приведение int в uint
                };
                appDBcontent.OrderDetail.Add(orderDetail);// добавляем в базу данных созданные объекты
            }

            appDBcontent.SaveChanges();
        }
    }
}