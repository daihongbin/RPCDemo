using Microsoft.AspNetCore.Mvc;

namespace GrpcDemo.AspGrpcServer.Controller
{
    [Route("api/Health")]
    public class HealthController: Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet]
        public IActionResult Get() => Ok("ok");
    }
}
