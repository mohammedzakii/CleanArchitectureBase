using CleanArchitectureBase.Application.Interfaces;
using CleanArchitectureBase.Domin.Entities;
using CleanArchitectureBase.Domin.Repositories;
using MediatR;

namespace CleanArchitectureBase.Application.Customers.Commands.Create
{
    public class AddNewCustomerCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public class Handler : IRequestHandler<AddNewCustomerCommand, string>
        {
            private readonly IApplicationDbContext _context;
            private readonly ICustomerRepository _customerRepository;

            public Handler(IApplicationDbContext context , ICustomerRepository customerRepository)
            {
                _context = context;
                _customerRepository = customerRepository;
            }
            public async Task<string> Handle(AddNewCustomerCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var newCustomer = new Customer
                    {
                        Email = request.Email,
                        Name = request.Name,
                        Phone = request.Phone,
                    };

                    var test =await _customerRepository.Add(newCustomer);
                    
                    return "Custmer Added Successfully";
                }
                catch (Exception ex)
                {
                    return "Data is not Valid";
                }
            }
        }
    }
}
