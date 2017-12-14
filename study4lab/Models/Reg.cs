using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace study4lab.Models
{
    public class Reg
    {
        public int Id { get; set; }
        
        //Имя
        public string FirstName { get; set; }

        //Фамилия
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string LastName { get; set; }
        
        //E-Mail
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string email { get; set; }
        
        //Номер телефона
        
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Phone { get; set; }

        //Пароль
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Password { get; set; }

        //Подтверждение пароля
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string PasswordConfirm { get; set; }
    }
}