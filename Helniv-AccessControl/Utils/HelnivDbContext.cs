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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .HasIndex(r => r.RoleConst)
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
