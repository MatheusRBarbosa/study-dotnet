using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public string Index()
        {
            return "pong";
        }

        [HttpGet("authed")]
        [Authorize]
        public string Authed()
        {
            return "Authed pong";
        }

        [HttpGet("admin")]
        [Authorize(Roles = "2")]
        public string Admin()
        {
            return "Admin pong";
        }
    }
}