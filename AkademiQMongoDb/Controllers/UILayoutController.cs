using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
