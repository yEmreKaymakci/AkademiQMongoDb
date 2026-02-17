using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _ChefViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
