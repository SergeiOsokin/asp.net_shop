using System;
using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order); // функция для создания заказа
    }
}
    