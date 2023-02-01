using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softtek.BizLogic;
using Softtek.BizLogic.Inter;
using System.Net;

namespace Softtek.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommercialController : ControllerBase
    {
        private ICommercialBL _commercialBL = null;

        public CommercialController()
        {
            _commercialBL = new CommercialBL();
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ListarVenta()
        {
            _commercialBL = new CommercialBL();
            var result = _commercialBL.ListarVenta();
            if (result.Count == 0)
                return BadRequest("No hay Datos");
            else
                return Ok(result);

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ListarVentaXProducto([FromBody] int idProducto)
        {
            _commercialBL = new CommercialBL();
            var result = _commercialBL.ListarVentaXProducto(idProducto);
            if (result.Count == 0)
                return BadRequest("No hay Datos");
            else
                return Ok(result);

        }
    }
}
