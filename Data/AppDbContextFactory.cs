using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PriorAuthPrototype.Data;

namespace PriorAuthPrototype.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=priorauth.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
