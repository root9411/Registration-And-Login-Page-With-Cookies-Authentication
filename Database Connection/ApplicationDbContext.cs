using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Database_Connection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserRegistration> registrations { get; set; }
        public DbSet<LoginUser> users { get; set; }
    }
}
