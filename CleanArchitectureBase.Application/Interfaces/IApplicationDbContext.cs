using CleanArchitectureBase.Domin.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBase.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customer { get; set; }
        Task<int> SaveChangesAsync();
    }
}
