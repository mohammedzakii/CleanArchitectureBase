using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureBase.Domin.Entities;

namespace CleanArchitectureBase.persistence.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(prob => prob.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Phone).IsRequired();
            builder.Property(a => a.Email).IsRequired();
            
        }
    }
}