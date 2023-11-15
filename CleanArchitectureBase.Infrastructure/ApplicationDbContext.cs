using CleanArchitectureBase.Application.Interfaces;
using CleanArchitectureBase.Domin.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBase.persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        
        }
        
        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(CancellationToken.None);
        }
    }
}