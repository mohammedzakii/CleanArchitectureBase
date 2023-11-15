using CleanArchitectureBase.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBase.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteCustomerCommand, string>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var customer = await _context.Customer.FirstOrDefaultAsync(a => a.Id == request.Id);

                    if (customer != null)
                    {
                        customer.IsDeleted = true;
                        await _context.SaveChangesAsync();

                        return "Custmer Deleted Successfully";
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
