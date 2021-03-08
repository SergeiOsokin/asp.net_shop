using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;

namespace Shop.Data
{ // будет добавлять объекты
    public class DBObjects
    {
        // статитические функции
        public static void Initial(AppDBContent content) {


            if (!content.Category.Any()) {
                content.Category.AddRange(Categories.Select(c => c.Value)); // получаем значения и устанавливаем их AddRange
            }
            // работа с автомобилями
            if (!content.Car.Any())
            {
                content.AddRange(
                     new Car
                    {
                        nameCar = "Tesla",
                        shortDescCar = "Бесшумная",
                        longDescCar = "Очень крутая",
                        imgCar = "/img/tesla.jpeg",
                        priceCar = 45000,
                        isFavouriteCar = true,
                        availableCar = true,
                        Category = Categories["Electro"] // получаем electro, т.к. она идет первой
                    },
                    new Car
                    {
                        nameCar = "Ford",
                        shortDescCar = "Шумная",
                        longDescCar = "Отлично где нет дорог",
                        imgCar = "/img/ford.jpg",
                        priceCar = 4000,
                        isFavouriteCar = false,
                        availableCar = true,
                        Category = Categories["Electro"] // получаем electro, т.к. она идет первой
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
                        Category = Categories["Classic"] // получаем electro, т.к. она идет первой
                    },
                    new Car
                    {
                        nameCar = "Cherry",
                        shortDescCar = "Китай",
                        longDescCar = "Отличный и дешевый",
                        imgCar = "/img/cherry.jpg",
                        priceCar = 130,
                        isFavouriteCar = false,
                        availableCar = true,
                        Category = Categories["Classic"] // получаем electro, т.к. она идет первой
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
                        Category = Categories["Electro"] // получаем electro, т.к. она идет первой
                    },
                    new Car
                    {
                        nameCar = "Mercedes",
                        shortDescCar = "Class A",
                        longDescCar = "Идеально для городской среды",
                        imgCar = "/img/mercedes.jpg",
                        priceCar = 12350,
                        isFavouriteCar = false,
                        availableCar = true,
                        Category = Categories["Classic"] // получаем electro, т.к. она идет первой
                    }


                ); // получаем значения и устанавливаем их AddRange
            }

            // сохраняем данные в бд
            content.SaveChanges();
        }


        // работа с категориями
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null) // если список категорий пустой, добавляем в базу
                {
                    var list = new Category[]{
                       new Category { categoryName = "Electro", desc = "Electro car" },
                       new Category { categoryName = "Classic", desc = "Classic car" }
                    };

                category = new Dictionary<string, Category>();
                foreach(Category element in list)
                {
                    category.Add(element.categoryName, element);
                }
                }
                return category;
            }

        }
    }
}
