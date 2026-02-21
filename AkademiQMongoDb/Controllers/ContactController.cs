using AkademiQMongoDb.DTOs.SendMessageDtos;
using AkademiQMongoDb.Services.ContactServices;
using AkademiQMongoDb.Services.SendMessageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ISendMessageService _sendMessageService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactService contactService, ISendMessageService sendMessageService, ILogger<ContactController> logger)
        {
            _contactService = contactService;
            _sendMessageService = sendMessageService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contact = await _contactService.GetAllAsync();
            var singleContact = contact.FirstOrDefault();
            return View(singleContact);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateSendMessageDto _createSendMessageDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["SendMessageError"] = "Lütfen formdaki tüm alanları eksiksiz ve doğru formatta doldurunuz.";
                return RedirectToAction("Index");
            }

            try
            {
                await _sendMessageService.CreateAsync(_createSendMessageDto);

                TempData["SendMessageSuccess"] = "Mesaj başarılı bir şekilde gönderildi!";
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "İletişim sayfasından mesaj gönderilirken veritabanı veya servis kaynaklı bir hata oluştu.");
                TempData["SendMessageError"] = "Mesajınız gönderilirken sistemsel bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
            }
            return RedirectToAction("Index");
        }
    }
}
