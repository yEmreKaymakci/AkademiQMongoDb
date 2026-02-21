using AkademiQMongoDb.DTOs.ContactDtos;
using AkademiQMongoDb.DTOs.SubscriberDtos;
using AkademiQMongoDb.Services.ContactServices;
using AkademiQMongoDb.Services.SubscriberServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class UILayoutController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ISubscriberService _subscriberService;

        public UILayoutController(IContactService contactService, ISubscriberService subscriberService)
        {
            _contactService = contactService;
            _subscriberService = subscriberService;
        }
        [HttpGet]

        public IActionResult Layout()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Subscribe(CreateSubscriberDto _createSubscriberDto)
        {
            var allSubscriber = await _subscriberService.GetAllAsync();

            bool isEmailExist = allSubscriber.Any(x => x.Email == _createSubscriberDto.Email);

            if (isEmailExist)
            {
                TempData["SubscribeMessage"] = "Bu e-posta adresi zaten mail bültenimize kayıtlı.";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            await _subscriberService.CreateAsync(_createSubscriberDto);

            TempData["SubscriberMessage"] = "Bültene başarıyla abone oldunuz! Harika lezzet fırsatları yakında gelen kutunuzda.";

            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
