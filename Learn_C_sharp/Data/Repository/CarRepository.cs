using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
// файл для работы с базой данных 
namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        // для работы с БД
        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent) // конструктор
        {
            this.appDBContent = appDBContent;
        }
        // получаем из базы какие-то данные и дальше отфильтровываем в зависимости от того, какие нужны
        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> getFavoriteCars => appDBContent.Car.Where(p => p.isFavouriteCar).Include(c => c.Category);

        public Car getParticularCar(int cardId) => appDBContent.Car.FirstOrDefault(p => p.id == cardId);
        
    }
}
