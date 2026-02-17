using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.DefaultComponents
{
    public class _VideoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
