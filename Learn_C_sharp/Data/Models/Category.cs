using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// файл с полями для категории. модель категории
namespace Shop.Data.Models {
    public class Category {

        public int id { get; set; }

        public string categoryName { get; set; }

        public string desc { get; set; }

        public List<Car> cars { get; set; } //создаем 
    }
}
