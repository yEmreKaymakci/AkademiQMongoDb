using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutService.GetAllAsync();
            return View(abouts);
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto aboutDto)
        {
            await _aboutService.CreateAsync(aboutDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateAbout(string id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto aboutDto)
        {
            await _aboutService.UpdateAsync(aboutDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
