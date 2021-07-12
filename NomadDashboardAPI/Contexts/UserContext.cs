using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NomadDashboardAPI.Models;

namespace NomadDashboardAPI.Contexts
{
    public class UserContext : IdentityDbContext
    {

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}