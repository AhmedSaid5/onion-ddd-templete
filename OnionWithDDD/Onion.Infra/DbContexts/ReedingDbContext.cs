using Microsoft.EntityFrameworkCore;
using Onion.Domain.BusinessDomain;

namespace Onion.Infra.DbContexts
{
    public class ReedingDbContext : DbContext
    {
        public ReedingDbContext(DbContextOptions<ReedingDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
