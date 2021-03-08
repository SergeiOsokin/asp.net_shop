using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> Allcategories
        {
            get // указываем какие категории необходимо возвращать
            {
                return new List<Category> // новые объекты на основе модели Category. По сути сколько у нас сейчас категорий
                {
                    new Category { categoryName = "Electro", desc =  "Electro car" },
                    new Category { categoryName = "Classic", desc = "Classic car" }
                };
            }
        }
    }
}
