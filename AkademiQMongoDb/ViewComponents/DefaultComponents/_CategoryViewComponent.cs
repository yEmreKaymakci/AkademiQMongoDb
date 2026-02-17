using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
