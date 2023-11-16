using CleanArchitectureBase.Domin.Customers.Models;
using CleanArchitectureBase.Domin.Entities;

namespace CleanArchitectureBase.Domin.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> Add(Customer customer);
        Task Update();
        Task Remove(Customer customer);
        Task<Customer> GetByIdAsync(int Id);
        Task<List<Customer>> GetAllAsync();
    }
}
 