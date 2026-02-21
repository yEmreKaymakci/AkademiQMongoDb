using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
