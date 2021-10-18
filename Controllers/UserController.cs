using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AuthApi.Context;
using AuthApi.Models;
using AuthApi.Dtos;
using AutoMapper;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AuthContext context;
        private readonly IMapper mapper;

        public UserController(AuthContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "2, 1")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await this.context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<UserDto>(user));
        }
    }
}