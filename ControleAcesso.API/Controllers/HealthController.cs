using Microsoft.AspNetCore.Mvc;

namespace ControleAcesso.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> Get()
        {
            try
            {
                var response = new
                {
                    DataAcesso = DateTime.Now.ToLongDateString(),
                    IPUsuario = HttpContext.Connection.RemoteIpAddress.ToString(),
                    Success = true
                };
                return Ok(response);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
