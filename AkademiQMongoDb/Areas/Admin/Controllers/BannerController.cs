using AkademiQMongoDb.DTOs.BannerDtos;
using AkademiQMongoDb.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IActionResult> Index()
        {
            var banner = await _bannerService.GetAllAsync();
            return View(banner);
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto BannerDto)
        {
            await _bannerService.CreateAsync(BannerDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateBanner(string id)
        {
            var Banner = await _bannerService.GetByIdAsync(id);
            return View(Banner);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto BannerDto)
        {
            await _bannerService.UpdateAsync(BannerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBanner(string id)
        {
            await _bannerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
