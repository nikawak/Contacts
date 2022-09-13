using Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using Contacts.Sevices;

namespace Contacts.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contacts = Mock.GetContacts();

            return View(contacts);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContact model)
        {
            var contact = new Contact()
            {
                Name = model.Name,
                JobTitle = model.JobTitle,
                BirthDate = model.BirthDate,
                MobilePhone = model.MobilePhone
            };
            return View("Index");
        }

        [HttpGet]
        public IActionResult EditContact(Guid id)
        {
            var contact = Mock.GetById(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult EditContact(Contact model)
        {

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}