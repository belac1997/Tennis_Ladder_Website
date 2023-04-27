using Microsoft.AspNetCore.Mvc;

namespace TennisLadder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
