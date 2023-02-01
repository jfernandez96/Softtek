using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softtek.BizLogic.Inter;
using Softtek.BizLogic;
using Microsoft.AspNetCore.Authorization;
using Softtek.Domain;

namespace Softtek.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SegurityController : ControllerBase
    {
        private ISegurityBL _segurityBL = null;

        public SegurityController()
        {
            _segurityBL = new SegurityBL();
        }


        [HttpPost]
        public IActionResult GetUser([FromBody] UserLogins itemRequest)
        {
            _segurityBL = new SegurityBL();
            var result = _segurityBL.GetUser(itemRequest);
            if (result == null)
                return BadRequest("No hay Datos");
            else
                return Ok(result);

        }
    }
}
