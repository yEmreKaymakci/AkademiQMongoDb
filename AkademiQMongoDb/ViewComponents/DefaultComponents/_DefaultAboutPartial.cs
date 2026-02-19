using AkademiQMongoDb.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultAboutPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _DefaultAboutPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAsync();
            var singleAbout = values.FirstOrDefault();
            return View(singleAbout);
        }
    }
}
