using System;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class CreateContact
    {
        [Required(ErrorMessage = "Поле \"Имя\" не должно быть пустым")]
        public string Name { get; set; }
        [Required]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        public string MobilePhone { get; set; }
        [Required(ErrorMessage = "Поле \"Работа\" не должно быть пустым")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Поле \"Дата рождения\" не должно быть пустым")]
        public DateTime BirthDate { get; set; }
    }
}