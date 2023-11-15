using CleanArchitectureBase.Application.Customers.Models;
using CleanArchitectureBase.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBase.Application.Customers.Queries
{
    public class GetCustomerById : IRequest<CustomerDataDto>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetCustomerById, CustomerDataDto>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<CustomerDataDto> Handle(GetCustomerById request, CancellationToken cancellationToken)
            {
                try
                {
                    var customer = await _context.Customer.Where(a=>a.Id == request.Id).Select(a => new CustomerDataDto
                    {
                        Name = a.Name,
                        Email = a.Email,
                        Phone = a.Phone,
                    }).FirstOrDefaultAsync();

                    return customer;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
