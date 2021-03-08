using System;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//интерфейс для получения всех категорий из  модели категори
namespace Shop.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> Allcategories { get; } // функция благодаря которой будем получать все доступные категории
    }
}
