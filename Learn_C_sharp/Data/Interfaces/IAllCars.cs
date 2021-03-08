using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Models;
// тут прописываем функции для получения car
namespace Shop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }// выводит все авто

        IEnumerable<Car> getFavoriteCars { get; }

        Car getParticularCar(int cardId);
    }
}
