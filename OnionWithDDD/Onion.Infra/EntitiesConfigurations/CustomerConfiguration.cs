using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Infra.EntitiesConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("id")
               .HasColumnType("uniqueidentifier")
               .HasDefaultValueSql("newid()");

            builder.Property(x => x.Name).HasMaxLength(255);

            builder.OwnsOne(c => c.Address, a =>
            {
                a.Property(p => p.State)
                .HasColumnName("state")
                .HasDefaultValue("")
                .HasMaxLength(255);

                a.Property(p => p.Country)
                .HasColumnName("country")
                .HasDefaultValue("")
                .HasMaxLength(255);

                a.Property(p => p.Zipcode)
                .HasColumnName("zip_code")
                .HasDefaultValue("")
                .HasMaxLength(255);

                a.Property(p => p.Street)
                .HasColumnName("street")
                .HasDefaultValue("")
                .HasMaxLength(255);

                a.Property(p => p.City)
               .HasColumnName("city")
               .HasDefaultValue("")
               .HasMaxLength(255);
            });

            builder.OwnsMany(c => c.CustomerContacts, cg =>
            {
                cg.ToTable("CustomerContacts");

                cg.Property(c => c.Id)
                .HasColumnName("Id")
                  .HasColumnType("uniqueidentifier")
               .HasDefaultValueSql("newid()");

                cg.Property(c => c.Name).HasMaxLength(255);
                cg.Property(c => c.ContactType).HasMaxLength(255);
                cg.Property(c => c.ContactInfo).HasMaxLength(255);

            });


            builder.Metadata.FindNavigation(nameof(Customer.CustomerContacts))
                .SetField("_customerContacts");

        }
    }
}
