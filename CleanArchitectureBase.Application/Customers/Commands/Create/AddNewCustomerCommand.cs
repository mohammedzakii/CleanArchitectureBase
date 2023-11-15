using CleanArchitectureBase.Application.Interfaces;
using CleanArchitectureBase.Domin.Entities;
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

            public Handler(IApplicationDbContext context)
            {
                _context = context;
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

                    _context.Customer.Add(newCustomer);
                    await _context.SaveChangesAsync();

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
