using Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using Contacts.Services;
using Contacts.Services.Intefaces;

namespace Contacts.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactRepository _contactRepository;

        public ContactController(ILogger<ContactController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = await _contactRepository.GetAllAsync();

            return View(contacts);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContact model)
        {
            var contact = new Contact()
            {
                Name = model.Name,
                JobTitle = model.JobTitle,
                BirthDate = model.BirthDate,
                MobilePhone = model.MobilePhone
            };
            await _contactRepository.CreateAsync(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditContact(Guid id)
        {
            var contact = await _contactRepository.GetAsync(id);
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> EditContact(Contact model)
        {
            await _contactRepository.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}