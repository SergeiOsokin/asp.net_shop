using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        public readonly IAllCars _carRep;
        public readonly ShopCart _shopCart;

        public ShopCartController (IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index() // возвращает шаблон
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItem = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        // переадресация на другую страницу
        public RedirectToActionResult addToCart(int id)
        {
            // обращаемся к хранилищу и добавляем в корзину конкретный товар (ищем по id)
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);

            if(item != null)
            {
                _shopCart.AddToCart(item); // добавление самого товара в корзину
            }

            return RedirectToAction("Index");
        }

    }
}
