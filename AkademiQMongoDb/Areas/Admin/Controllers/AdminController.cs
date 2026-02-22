using AkademiQMongoDb.DTOs.AdminDtos;
using AkademiQMongoDb.Services.AdminServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            var admin = await _adminService.GetAllAsync();
            return View(admin);
        }

        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminDto AdminDto)
        {
            await _adminService.CreateAdminAsync(AdminDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateAdmin(string UserName)
        {
            var Admin = await _adminService.GetAdminByUserNameAsync(UserName);
            return View(Admin);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminDto AdminDto)
        {
            await _adminService.UpdateAsync(AdminDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAdmin(string id)
        {
            await _adminService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
