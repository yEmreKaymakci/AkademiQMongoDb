using AkademiQMongoDb.Services.AboutServices;
using AkademiQMongoDb.Services.ChefServices;
using AkademiQMongoDb.Services.ProductServices;
using AkademiQMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IProductService _productService;
        private readonly ITestimonialService _testimonialService;
        private readonly IChefService _chefService;

        public AboutController(IAboutService aboutService, IProductService productService, ITestimonialService testimonialService, IChefService chefService)
        {
            _aboutService = aboutService;
            _productService = productService;
            _testimonialService = testimonialService;
            _chefService = chefService;
        }

        public async Task<IActionResult> Index()
        {
            //HAkkımızda verisi
            var aboutValues = await _aboutService.GetAllAsync();
            var getSingleAbout = aboutValues.FirstOrDefault();
            //Ürün Sayısı
            var products = await _productService.GetAllAsync();
            ViewBag.ProductCount = products.Count;
            //Referansları çekme
            var testimonials = await _testimonialService.GetAllAsync();
            ViewBag.Testimonials = testimonials;
            //Şef sayısı çekme
            var chefs = await _chefService.GetAllAsync();
            ViewBag.ChefCount = chefs.Count;

            return View(getSingleAbout);

        }
    }
}
