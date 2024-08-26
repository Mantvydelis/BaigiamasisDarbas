using Microsoft.AspNetCore.Mvc;

namespace Parduotuve.API.Controllers
{
    public class ProductaiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
