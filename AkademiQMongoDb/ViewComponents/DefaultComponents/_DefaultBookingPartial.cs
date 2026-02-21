using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultBookingPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultBookingPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllAsync();

            ViewBag.ProductCount = products.Count;
            return View();
        }
    }
}
