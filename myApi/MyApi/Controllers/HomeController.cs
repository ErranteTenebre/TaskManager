using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
