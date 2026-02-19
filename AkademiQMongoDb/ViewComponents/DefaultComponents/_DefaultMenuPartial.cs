using System.Threading.Tasks;
using AkademiQMongoDb.Services.CategoryServices;
using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultMenuPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultMenuPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allProducts = await _productService.GetAllAsync();

            var fastFoodProducts = allProducts
                .Where(x => x.CategoryName == "Tavuk Burger").Take(2)
                .Concat(allProducts.Where(x => x.CategoryName == "Tavuk Kova").Take(2))
                .ToList();

            var dessertProducts = allProducts
                .Where(x => x.CategoryName == "Tatlı").Take(4)
                .ToList();

            ViewBag.Desserts = dessertProducts;

            var fastFoodImage = allProducts.FirstOrDefault(x => x.CategoryName == "Tavuk Burger")?.ImageUrl;
            var dessertImage = allProducts.FirstOrDefault(x => x.CategoryName == "Tatlı")?.ImageUrl;

            ViewBag.FoodImage = fastFoodImage;
            ViewBag.DessertImage = dessertImage;

            return View(fastFoodProducts);
        }
    }
}
