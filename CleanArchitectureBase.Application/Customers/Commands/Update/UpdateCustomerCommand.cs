using CleanArchitectureBase.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBase.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public class Handler : IRequestHandler<UpdateCustomerCommand, string>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                try
                {

                    var customer = await _context.Customer.FirstOrDefaultAsync(a => a.Id == request.Id);

                    if (customer != null)
                    {

                        if (!string.IsNullOrEmpty(request.Email))
                            customer.Email = request.Email;

                        if (!string.IsNullOrEmpty(request.Phone))
                            customer.Phone = request.Phone;

                        if (!string.IsNullOrEmpty(request.Name))
                            customer.Name = request.Name;

                        await _context.SaveChangesAsync();

                        return "Custmer Updated Successfully";
                    }
                    else
                    {
                        return "Customer Not Found";
                    }
                }
                catch (Exception ex)
                {
                    return "Data is not Valid";
                }
            }
        }
    }

}