using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace study4lab.Models
{
    public class RegLogin
    {
        //E-Mail
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string email { get; set; }

        //Пароль
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Password { get; set; }
    }
}