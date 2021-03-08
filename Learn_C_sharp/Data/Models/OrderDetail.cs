using System;

// 
namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderAD { get; set; } //айди конкретного заказа
        public int carId { get; set; } // идентификатор конкретной машины
        public uint price { get; set; }
        //связка объекта товара с заказом (order and car)
        public virtual Car car { get; set; } //объект машину которую приобретаем
        public virtual Order order { get; set; } // сам заказ


    }
}
