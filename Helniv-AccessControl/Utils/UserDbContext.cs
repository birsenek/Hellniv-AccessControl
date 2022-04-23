using Microsoft.EntityFrameworkCore;
using Helniv_AccessControl.Entities;

namespace Helniv_AccessControl.Utils
{
    public class UserDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }
    }
}
