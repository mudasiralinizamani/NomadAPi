using Microsoft.EntityFrameworkCore;
using NomadDashboardAPI.Models;

namespace NomadDashboardAPI.Contexts
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }

        public DbSet<Lead> Leads { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}