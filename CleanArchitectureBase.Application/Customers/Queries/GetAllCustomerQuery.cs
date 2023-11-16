using CleanArchitectureBase.Domin.Entities;
using CleanArchitectureBase.Domin.Repositories;
using MediatR;

namespace CleanArchitectureBase.Application.Customers.Queries
{
    public class GetAllCustomerQuery : IRequest<List<Customer>>
    {
        public class Handler : IRequestHandler<GetAllCustomerQuery, List<Customer>>
        {
            private readonly ICustomerRepository _customerRepository;

            public Handler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var customer = await _customerRepository.GetAllAsync();
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
