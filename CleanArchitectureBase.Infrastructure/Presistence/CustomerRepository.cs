using CleanArchitectureBase.Application.Interfaces;
using CleanArchitectureBase.Domin.Customers.Models;
using CleanArchitectureBase.Domin.Entities;
using CleanArchitectureBase.Domin.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBase.Infrastructure.Presistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IApplicationDbContext _context;
        public CustomerRepository(IApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<int> Add(Customer customer)
        {
            try
            {
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();
                return 1;
            }catch (Exception ex)
            {
                throw new Exception("Data Not Vaild");
            }
        }

        public async Task<Customer> GetByIdAsync(int Id)
        {
            try
            {
                var customer = await _context.Customer.Where(a => a.Id == Id).FirstOrDefaultAsync();
                return customer;
            }catch (Exception ex)
            {
                throw new Exception("Data Not Vaild");
            }
        }
        
        public async Task<List<Customer>> GetAllAsync()
        {
            try { 
            var customer = await _context.Customer.ToListAsync();
            return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("Data Not Vaild");
            }
        }


        public async Task Remove(Customer customer)
        {
            try { 
            customer.IsDeleted = true;
            await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Data Not Vaild");
            }
        }

        public async Task Update()
        {
            try { 
            await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Data Not Vaild");
            }
        }

       
    }
}
