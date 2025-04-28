using Microsoft.EntityFrameworkCore;
using PriorAuthPrototype.Models;

namespace PriorAuthPrototype.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //represents table in database
        public DbSet<PriorAuthorizationRequest> PriorAuthorizationRequests { get; set; }
    }
}
