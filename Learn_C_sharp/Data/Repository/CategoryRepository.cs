using System;
using System.Collections.Generic;
using Shop.Data.Interfaces;
using Shop.Data.Models;
// файл для работы с базой данных
namespace Shop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent) // конструктор
        {
            this.appDBContent = appDBContent;
        }
        // получаем из базы какие-то данные и отдаем их все
        public IEnumerable<Category> Allcategories => appDBContent.Category;
    }
}
