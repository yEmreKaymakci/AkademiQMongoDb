using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        //Invoke methodu eğer asenkronk olursa  InvokeAsync olarak yazılmalı!!
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = await _productService.GetAllAsync();
            return View(product);
        }

    }
}
