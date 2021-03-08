using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic.CompilerServices;
// поля формы для заказа
namespace Shop.Data.Models
{
    public class Order
    {

        [BindNever]// поле которое ниже никогда не будет показываться
        public int id { get; set; }
        [Display(Name = "Введите имя")] // с каким название поле будет отображатсья на странице
        [StringLength(25)] // проверка на длинну
        [Required(ErrorMessage = "Длинна имени не меньше 4 символов")] // сообщение с ошибкой
        public string name { get; set; }

        [Display(Name = "Введите фамилию")] // с каким название поле будет отображатсья на странице
        [StringLength(25)] // проверка на длинну
        [Required(ErrorMessage = "Длинна фамилии не меньше 4 символов")] // сообщение с ошибкой
        public string surName { get; set; }

        [Display(Name = "Введите адрес")] // с каким название поле будет отображатсья на странице
        [StringLength(25)] // проверка на длинну
        [Required(ErrorMessage = "Длинна адреса не меньше 4 символов")] // сообщение с ошибкой
        public string adress { get; set; }

        [Display(Name = "Введите телефон")] // с каким название поле будет отображатсья на странице
        [StringLength(10)] // проверка на длинну
        [Required(ErrorMessage = "Длинна телефона не меньше 4 символов")] // сообщение с ошибкой
        public string phone { get; set; }

        [Display(Name = "Введите емайл")] // с каким название поле будет отображатсья на странице
        [DataType(DataType.EmailAddress)]
        [StringLength(25)] // проверка на длинну
        [Required(ErrorMessage = "Длинна емайл не меньше 4 символов")] // сообщение с ошибкой
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)] // скроется из кода
        public DateTime orderTime { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }//список заказа
    }
}
