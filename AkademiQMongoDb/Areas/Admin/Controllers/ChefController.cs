using AkademiQMongoDb.DTOs.ChefDtos;
using AkademiQMongoDb.Services.ChefServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChefController : Controller
    {
        private readonly IChefService _chefService;

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }

        public async Task<IActionResult> Index()
        {
            var chefs = await _chefService.GetAllAsync();
            return View(chefs);
        }

        public IActionResult CreateChef()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChef(CreateChefDto ChefDto)
        {
            await _chefService.CreateAsync(ChefDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateChef(string id)
        {
            var chef = await _chefService.GetByIdAsync(id);
            return View(chef);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateChef(UpdateChefDto ChefDto)
        {
            await _chefService.UpdateAsync(ChefDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteChef(string id)
        {
            await _chefService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
