using AkademiQMongoDb.Services.AdminServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutNavbarViewComponent(IAdminService _adminService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (!string.IsNullOrEmpty(userName))
            {
                var admin = await _adminService.GetAdminByUserNameAsync(userName);
                if (admin != null)
                {
                    ViewBag.fullName = string.Join(" ", admin.FirstName, admin.LastName);
                }
            }
            return View();
        }
    }
}
