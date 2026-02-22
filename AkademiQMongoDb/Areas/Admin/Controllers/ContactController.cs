using AkademiQMongoDb.DTOs.ContactDtos;
using AkademiQMongoDb.DTOs.AdminDtos;
using AkademiQMongoDb.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var contact = await _contactService.GetAllAsync();
            return View(contact);
        }

        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto ContactDto)
        {
            await _contactService.CreateAsync(ContactDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateContact(string id)
        {
            var Contact = await _contactService.GetByIdAsync(id);
            return View(Contact);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto ContactDto)
        {
            await _contactService.UpdateAsync(ContactDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
