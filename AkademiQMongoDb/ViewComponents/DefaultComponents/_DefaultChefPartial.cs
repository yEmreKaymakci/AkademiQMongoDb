using AkademiQMongoDb.Services.ChefServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultChefPartial : ViewComponent
    {
        private readonly IChefService _chefService;

        public _DefaultChefPartial(IChefService chefService)
        {
            _chefService = chefService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _chefService.GetAllAsync();
            return View(values);
        }
    }
}
