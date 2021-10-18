using Microsoft.AspNetCore.Mvc;
using AuthApi.Models;
using AuthApi.Context;
using AuthApi.Services;
using BCryptNet = BCrypt.Net.BCrypt;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : ControllerBase
    {
        private readonly AuthContext context;
        private readonly AuthenticationService authService;

        public LoginController(AuthContext context, AuthenticationService authService)
        {
            this.context = context;
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Authenticate(AuthRequest request)
        {
            var user = this.context.users.SingleOrDefault(u => u.cpf == request.cpf);

            if (user == null)
            {
                return NotFound();
            }

            if (!BCryptNet.Verify(request.password, user.password))
            {
                return BadRequest(new { error = "Invalid Credentials" });
            }

            var token = this.authService.GenerateToken(user);
            return new { token };
        }
    }
}