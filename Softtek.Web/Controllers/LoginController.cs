using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softtek.Domain;

namespace Softtek.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserLogins model)
        {
            try
            {
                //var resultAPI = new LoginContext().Login(itemRequest);

                //if (resultAPI.ErrorCode != (int)Enumeradores.ResponseCode.CorrectCode)
                //    throw new Exception(resultAPI.ErrorDescription);


                //string[] ruta = ListMenu.FirstOrDefault().Ruta.Split('/');
                //GenerarTickectAutenticacion(usuario, ListMenu);
                return RedirectToAction("Index", "Home");


            }
            catch (Exception exception)
            {
                ViewBag.MessageError = exception.Message;
            }
            return View(model);
        }

        public IActionResult LogOut()
        {
            //LimpiarAutenticacion();
            return View("Index");
        }

    }
}
