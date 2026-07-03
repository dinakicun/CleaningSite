using CleaningSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CleaningSite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
        }

        public DbSet<ContactRequest> ContactRequests { get; set; }
    }
}
