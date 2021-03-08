using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public readonly IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }       
            
        public ViewResult Index ()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.getFavoriteCars
            };
            return View(homeCars);
        } 

    }
}
