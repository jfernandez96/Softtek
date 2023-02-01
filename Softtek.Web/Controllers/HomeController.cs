using Microsoft.AspNetCore.Mvc;
using Softtek.Web.DynamicClient;

namespace Softtek.Web.Controllers
{
    public class HomeController : Controller
    {
        private SegurityClient oSegurityClient = null;

        public IActionResult Index()
        {
            return View();
        }
    }
}
