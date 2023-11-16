using CleanArchitectureBase.Application.Interfaces;
using CleanArchitectureBase.Domin.Entities;
using CleanArchitectureBase.Domin.Repositories;
using MediatR;

namespace CleanArchitectureBase.Application.Customers.Queries
{
    public class GetCustomerById : IRequest<Customer>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetCustomerById, Customer>
        {
            private readonly IApplicationDbContext _context;
            private readonly ICustomerRepository _customerRepository;

            public Handler(IApplicationDbContext context, ICustomerRepository customerRepository)
            {
                _context = context;
                _customerRepository = customerRepository;
            }
            public async Task<Customer> Handle(GetCustomerById request, CancellationToken cancellationToken)
            {
                try
                {
                    var customer = await _customerRepository.GetByIdAsync(request.Id);   
                    return customer;
                }
                catch (Exception ex)
                {
                    throw new Exception("Data Not Vaild");
                }
            }
        }
    }
}
