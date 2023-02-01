using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softtek.Common;
using Softtek.Domain;
using Softtek.Domain.Dto;
using Softtek.Web.DynamicClient;

namespace Softtek.Web.Controllers
{
    public class LoginController : Controller
    {
        #region [Properties]
        private SegurityClient oSegurityClient = null;
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserLogins model)
        {
            UserDTO result = new UserDTO();
            try
            {
                oSegurityClient = new SegurityClient();

                #region [Invoke API]
                result = oSegurityClient.GetUser(new UserLogins
                {
                    UserName = model.UserName,
                    Password = model.Password
                });
                #endregion

                if (result.Usuario == null)
                    throw new Exception(Mensajes.UsuarioNoExiste);
             
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
