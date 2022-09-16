using System;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class CreateContact
    {
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string? JobTitle { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.MinValue;
    }
}