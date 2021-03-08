using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory(); // создали объект с категориями из MockCategory.cs

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car> // на основе модели Car создаем автомобили
                {
                    new Car
                    {
                        nameCar = "Tesla",
                        shortDescCar = "Бесшумная",
                        longDescCar = "Очень крутая",
                        imgCar = "/img/tesla.jpeg",
                        priceCar = 45000,
                        isFavouriteCar = true,
                        availableCar = true,
                        Category = _categoryCars.Allcategories.First() // получаем electro, т.к. она идет первой
                        // Category = _categoryCars.Allcategories.Last() так получили бы classic
                    },
                    new Car
                    {
                        nameCar = "Ford",
                        shortDescCar = "Шумная",
                        longDescCar = "Отлично где нет дорог",
                        imgCar = "/img/ford.jpg",
                        priceCar = 4000,
                        isFavouriteCar = true,
                        availableCar = true,
                        Category = _categoryCars.Allcategories.Last() // получаем electro, т.к. она идет первой
                    },
                    new Car
                    {
                        nameCar = "BMW",
                        shortDescCar = "Огонь",
                        longDescCar = "Часто ломается, впрочем ...",
                        imgCar = "/img/bmw.jpg",
                        priceCar = 34999,
                        isFavouriteCar = true,
                        availableCar = true,
                        Category = _categoryCars.Allcategories.Last() // получаем electro, т.к. она идет первой
                    },
                    new Car
                    {
                        nameCar = "Cherry",
                        shortDescCar = "Китай",
                        longDescCar = "Отличный и дешевый",
                        imgCar = "/img/cherry.jpg",
                        priceCar = 130,
                        isFavouriteCar = true,
                        availableCar = true,
                        Category = _categoryCars.Allcategories.Last() // получаем electro, т.к. она идет первой
                    },
                    new Car
                    {
                        nameCar = "Aston Martin",
                        shortDescCar = "Бесценный",
                        longDescCar = "Этим все сказано",
                        imgCar = "/img/aston_martin.jpeg",
                        priceCar = 860,
                        isFavouriteCar = true,
                        availableCar = true,
                        Category = _categoryCars.Allcategories.First() // получаем electro, т.к. она идет первой
                    },
                    new Car
                    {
                        nameCar = "Mercedes",
                        shortDescCar = "Class A",
                        longDescCar = "Идеально для городской среды",
                        imgCar = "/img/mercedes.jpg",
                        priceCar = 12350,
                        isFavouriteCar = true,
                        availableCar = true,
                        Category = _categoryCars.Allcategories.Last() // получаем electro, т.к. она идет первой
                    }
                };
            }
        }
        public IEnumerable<Car> getFavoriteCars { get; set; }

        public Car getParticularCar(int cardId)
        {
            throw new NotImplementedException();
        }
    }
}
