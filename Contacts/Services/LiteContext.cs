using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Services
{
    public class LiteContext : DbContext
    {
        public static string DbPath 
        {
            get
            {
                var appdataFolder = Environment.SpecialFolder.LocalApplicationData;
                var bdFolder = Directory.CreateDirectory(Path.Join(Environment.GetFolderPath(appdataFolder), "NikawakContactsApp"));
                var bdFile = Path.Join(bdFolder.FullName, "Contacts.db");
                return bdFile;
            }
        }

    public LiteContext(DbContextOptions<LiteContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }

    }
}
