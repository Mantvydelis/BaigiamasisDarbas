using Microsoft.AspNetCore.Mvc;

namespace Parduotuve.API.Controllers
{
    public class UzsakymaiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
