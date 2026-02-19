using AkademiQMongoDb.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultMainSliderPartial : ViewComponent
    {
        private readonly IBannerService _bannerService;

        public _DefaultMainSliderPartial(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bannerService.GetAllAsync();
            return View(values);
        }
    }
}
