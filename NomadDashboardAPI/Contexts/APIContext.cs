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
    }
}