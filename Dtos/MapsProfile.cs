using AutoMapper;
using AuthApi.Models;
namespace AuthApi.Dtos
{
    public class MapsProfile : Profile
    {
        public MapsProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
        }
    }
}