using AkademiQMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _DefaultTestimonialPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialService.GetAllAsync();
            return View(values);
        }
    }
}
