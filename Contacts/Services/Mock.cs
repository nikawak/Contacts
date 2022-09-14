using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Services
{
    public static class Mock
    {
        private static List<Contact> contacts { get; set; }
        private static List<Contact> Contacts
        {
            get
            {
                if (contacts == null)
                    contacts = new List<Contact>()
                    {
                        new Contact()
                        {
                            Id = Guid.NewGuid(), Name = "Евгений", MobilePhone = "+375 (33) 325 71 96",
                            BirthDate = DateTime.Now, JobTitle = "Программист"
                        },
                        new Contact()
                        {
                            Id = Guid.NewGuid(), Name = "Максим", MobilePhone = "+375 (29) 73 40 275",
                            BirthDate = DateTime.Now, JobTitle = "Машинист"
                        },
                        new Contact()
                        {
                            Id = Guid.NewGuid(), Name = "Саша", MobilePhone = "+375 (29) 88 350 87",
                            BirthDate = DateTime.Now, JobTitle = "Приколист"
                        },
                        new Contact()
                        {
                            Id = Guid.NewGuid(), Name = "Паша", MobilePhone = "+375 (29) 58 29 095",
                            BirthDate = DateTime.Now, JobTitle = "БелыйЛист"
                        }
                    };
                return contacts;
                }
        }
        public static Contact GetById(Guid id)
        {
            return Contacts.FirstOrDefault(x=>x.Id == id);
        }
        public static IEnumerable<Contact> GetContacts()
        {
            return Contacts;
        }
    }
}
