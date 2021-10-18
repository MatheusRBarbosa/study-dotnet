using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AuthApi.Context;
using AuthApi.Models;
using AuthApi.Dtos;
using AuthApi.Requests;
using AuthApi.Services;
using AutoMapper;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AuthContext context;
        private readonly IMapper mapper;
        private readonly UserService userService;

        public UserController(AuthContext context, IMapper mapper, UserService userService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "2, 1")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await this.userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Create(CreateUserRequest request)
        {
            var user = await this.userService.Create(request);
            return Ok(user);
        }
    }
}