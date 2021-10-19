using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AuthApi.Context;
using AuthApi.Models;
using AuthApi.Requests;
using AuthApi.Dtos;

namespace AuthApi.Services
{
    public interface IUserService
    {
        Task<User> Create(CreateUserRequest request);
        Task<UserDto> Get(int id);
    }

    public class UserService : IUserService
    {
        private readonly AuthContext context;
        private readonly IMapper mapper;

        public UserService(AuthContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<User> Create(CreateUserRequest request)
        {
            var password = BCryptNet.HashPassword(request.password);
            var user = new User
            {
                name = request.name,
                active = true,
                blocked = true,
                cpf = request.cpf,
                cellphone = request.cellphone,
                password = password,
                roleId = 2
            };

            this.context.users.Add(user);
            await this.context.SaveChangesAsync();

            return user;
        }

        public async Task<UserDto> Get(int id)
        {
            var user = await this.context.users
                .Include(user => user.role)
                .FirstAsync(user => user.id == id);

            return this.mapper.Map<UserDto>(user);
        }
    }
}