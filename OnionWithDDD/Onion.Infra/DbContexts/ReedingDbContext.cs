using Microsoft.EntityFrameworkCore;
using Onion.Domain.BusinessDomain;

namespace Onion.Infra.DbContexts
{
    public class ReedingDbContext : DbContext
    {
        public ReedingDbContext(DbContextOptions<ReedingDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>();
            //modelBuilder.Entity<CustomerContact>();
            //modelBuilder.Entity<Address>().HasNoKey();

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurations();
        }
    }
}
