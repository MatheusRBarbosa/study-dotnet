using BCryptNet = BCrypt.Net.BCrypt;
using AutoMapper;
using AuthApi.Context;
using AuthApi.Models;
using AuthApi.Requests;
using AuthApi.Dtos;

namespace AuthApi.Services
{
    public class UserService
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
            var user = await this.context.users.FindAsync(id);
            return this.mapper.Map<UserDto>(user);
        }
    }
}