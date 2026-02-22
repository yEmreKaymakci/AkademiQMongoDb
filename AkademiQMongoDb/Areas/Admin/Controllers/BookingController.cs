using AkademiQMongoDb.DTOs.BookingDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Services.BookingServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var booking = await _bookingService.GetAllAsync();
            return View(booking);
        }

        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto bookingDto)
        {
            await _bookingService.CreateAsync(bookingDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateBooking(string id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto bookingDto)
        {
            await _bookingService.UpdateAsync(bookingDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
