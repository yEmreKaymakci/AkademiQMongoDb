using AkademiQMongoDb.Services.CategoryServices;
using AkademiQMongoDb.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public MenuController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            //
            var product = await _productService.GetAllAsync();
            return View(product);
        }
    }
}
