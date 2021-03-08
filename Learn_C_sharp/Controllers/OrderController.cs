// когда создаем контроллер, не забывать создавать View
using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders; // для работы с базой данных
        private readonly ShopCart shopCart; // сама корзина, что в ней есть

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult CheckOut () //возвращает Views/Order/Checkout
        {
            return View();
        }

        [HttpPost] // функция ниже вызывается когда происходит отправка данных в данном случае пользователь нажимает Finish order
        public IActionResult CheckOut(Order order) //возвращает View
        {

            shopCart.listShopItem = shopCart.getShopItems(); // берем все товары которые есть
            if(shopCart.listShopItem.Count == 0)
            {
                ModelState.AddModelError("", "Отсутсвуют товары в корзине");
            }
            else if(ModelState.IsValid) //вернет тру, только если на форме нет ошибок
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order); //так как View возвращаем с объектом, то поля формы будут заполнены даже после перезагрузки, например, когда по части полей ошибка
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

    }
}
