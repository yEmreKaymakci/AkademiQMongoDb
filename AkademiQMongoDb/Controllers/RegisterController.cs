using AkademiQMongoDb.DTOs.AdminDtos;
using AkademiQMongoDb.Services.AdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class RegisterController(IAdminService _adminService) : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(CreateAdminDto createAdminDto)
        {
            await _adminService.CreateAdminAsync(createAdminDto);
            return RedirectToAction("Index", "Login");
        }
    }
}
