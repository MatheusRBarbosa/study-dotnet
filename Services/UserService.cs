using AuthApi.Context;
using AuthApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AuthApi.Services
{
    public class UserService
    {
        private readonly AuthContext context;

        public UserService(AuthContext context)
        {
            this.context = context;
        }

        // public async Task<User> Get(int id)
        // {
        //     var user = this.context.Users.FindAsync(id);
        //     if (user == null)
        //     {
        //         return ContentResult(StatusCodes.Status404NotFound)
        //     }
        // }
    }
}