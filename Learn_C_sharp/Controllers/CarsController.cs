using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

// различные функции, которые будут возвращать разные View html страницы
// html ищутся функцией View в папке Views и в папке содержащий название котроллера. в данном случае Cars
namespace Shop.Controllers {
    public class CarsController : Controller { // контроллер обязательно должен наследоваться от класса Controller

        private readonly IAllCars _allCars; // создаем объект интерфейса для 
        private readonly ICarsCategory _allCategory;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCategory) {
            _allCars = iAllCars;
            _allCategory = iCarsCategory;
        }

        [Route("Cars/List")] // при каком адресе должна срабатывать функция ниже
        [Route("Cars/List/{category}")]
        public ViewResult List(string category) //название такое же, что нужно вернуть из views cars list  
        {
            string _category = category;
            IEnumerable<Car> cars; // создаем коллекцию автомобилей
            string currentCategory = "";
            // в зависимости от url будем оперделять показать все автомобили или конкретные
            if(string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);// показываем все автомобили
            }
            else if (string.Equals("Electro", category, StringComparison.OrdinalIgnoreCase)) 
            {
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Electro"));// электрокары
                currentCategory = "Electro";
            }
            else
            {
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Classic"));// классические
                currentCategory = "Classic";
            }

            // ViewBag.Category = "Some new"; // ViewBag автоматически передаются в View. Category - может быть любым названием. Some new" может быть чем угодно
            ViewBag.Title = "Страница с авто";

            var carObj = new CarsListViewModel()
            {
                allCars = cars,
                currentCategory = currentCategory
            };
            return View(carObj); // передаем в html список машин которые необходимо отобразить
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
