using Microsoft.EntityFrameworkCore;
using AuthApi.Models;

namespace AuthApi.Context
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}