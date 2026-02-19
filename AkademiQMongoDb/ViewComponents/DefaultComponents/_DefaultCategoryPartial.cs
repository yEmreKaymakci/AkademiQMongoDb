using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class CategoryShowcaseModel
    {
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public string ImageUrl { get; set; }
    }

    public class _DefaultCategoryPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultCategoryPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllAsync();

            var categoryList = products
                .GroupBy(x => x.CategoryName)
                .Select(group => new CategoryShowcaseModel
                {
                    CategoryName = group.Key,
                    ProductCount = group.Count(),
                    ImageUrl = group.First().ImageUrl
                })
                .ToList();
            return View(categoryList);
        }
    }
}
