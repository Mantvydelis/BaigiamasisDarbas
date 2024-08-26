using Microsoft.AspNetCore.Mvc;

namespace Parduotuve.API.Controllers
{
    public class VartotojaiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
