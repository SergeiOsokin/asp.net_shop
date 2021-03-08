using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// модель описывающая машину/ по сути какие есть поля у нее
namespace Shop.Data.Models
{
    public class Car
    {
        public int id { get; set; }

        public string nameCar { get; set; }

        public string shortDescCar { get; set; }

        public string longDescCar { get; set; }

        public string imgCar { get; set; }

        public int priceCar { get; set; }

        public bool isFavouriteCar { get; set; }

        public bool availableCar { get; set; }

        public int categoryIDCar { get; set; }
        public virtual Category Category { get; set; } //тянем модель из файла Category.cs. Т.е. создаем объект модели
    }
}
