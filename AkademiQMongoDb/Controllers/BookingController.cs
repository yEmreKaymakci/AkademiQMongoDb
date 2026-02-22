using AkademiQMongoDb.DTOs.BookingDtos;
using AkademiQMongoDb.DTOs.SendMessageDtos;
using AkademiQMongoDb.Services.BookingServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Booking(CreateBookingDto _createBookingDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["BookingError"] = "Lütfen formdaki tüm alanları eksiksiz ve doğru formatta doldurunuz.";
                return RedirectToAction("Index");
            }

            try
            {
                await _bookingService.CreateAsync(_createBookingDto);

                TempData["BookingSuccess"] = "Rezervasyon başarılı bir şekilde tamamlandı!";
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Rezervasyon sayfasından rezervasyon yapılırken veritabanı veya servis kaynaklı bir hata oluştu.");
                TempData["BookingError"] = "Rezervasyon yapılırken sistemsel bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
            }
            return RedirectToAction("Index");

        }
    }
}
