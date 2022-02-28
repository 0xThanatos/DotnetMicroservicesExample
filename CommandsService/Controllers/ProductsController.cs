using Microsoft.AspNetCore.Mvc;

namespace MagenecompCommandsServices.Controllers
{
  [Route("api/c/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    public ProductsController()
    {

    }

    [HttpPost]
    public ActionResult TestInboundConnection()
    {
      Console.WriteLine("--> Inbound POST # Command Service");
      return Ok("Inbound test of from Products Controller");
    }
  }
}