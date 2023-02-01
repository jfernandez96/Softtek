using Microsoft.AspNetCore.Mvc;

namespace Softtek.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
