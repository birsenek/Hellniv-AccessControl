using Microsoft.EntityFrameworkCore;
using Helniv_AccessControl.Entities;

namespace Helniv_AccessControl.Utils
{
    public class HelnivDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public HelnivDbContext(DbContextOptions<HelnivDbContext> options) : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
