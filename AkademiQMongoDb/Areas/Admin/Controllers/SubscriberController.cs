using AkademiQMongoDb.DTOs.SubscriberDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Services.EmailServices;
using AkademiQMongoDb.Services.SubscriberServices;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscriberController : Controller
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IEmailService _emailService;

        public SubscriberController(ISubscriberService subscriberService, IEmailService emailService)
        {
            _subscriberService = subscriberService;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var subscriber = await _subscriberService.GetAllAsync();
            return View(subscriber);
        }

        // MAİL GÖNDERME METODU BURASI
        public async Task<IActionResult> SendDiscountEmails()
        {
            // 1. Veritabanındaki tüm aboneleri çek
            var subscribers = await _subscriberService.GetAllAsync();

            // 2. Abonelerin içinden sadece E-Posta adreslerini ayıkla (List<string> haline getir)
            var emailList = subscribers.Select(x => x.Email).ToList();

            // 3. Eğer listede en az 1 kişi varsa mail servisini tetikle
            if (emailList.Any())
            {
                await _emailService.SendDiscountEmailToSubscribersAsync(emailList);
                TempData["MailSuccess"] = "İndirim mailleri tüm abonelere başarıyla gönderildi!";
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateSubscriber()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(CreateSubscriberDto SubscriberDto)
        {
            await _subscriberService.CreateAsync(SubscriberDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubscriber(string id)
        {
            var subscriber = await _subscriberService.GetByIdAsync(id);

            // 2. ÇÖZÜM: View'ın çökmemesi için gelen veriyi UpdateSubscriberDto'ya dönüştürüyoruz
            var updateModel = subscriber.Adapt<UpdateSubscriberDto>();

            // 3. Dönüştürülmüş doğru modeli sayfaya gönderiyoruz
            return View(updateModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscriber(UpdateSubscriberDto SubscriberDto)
        {
            await _subscriberService.UpdateAsync(SubscriberDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSubscriber(string id)
        {
            await _subscriberService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
