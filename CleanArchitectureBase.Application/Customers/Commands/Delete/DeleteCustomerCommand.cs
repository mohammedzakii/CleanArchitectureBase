using CleanArchitectureBase.Application.Interfaces;
using CleanArchitectureBase.Domin.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBase.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteCustomerCommand, string>
        {
            private readonly ICustomerRepository _customerRepository;
            public Handler(ICustomerRepository customerRepository)
            {
                 _customerRepository = customerRepository;
            }
            public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var customer = await _customerRepository.GetByIdAsync(request.Id);

                    if (customer != null)
                    {
                        await _customerRepository.Remove(customer);

                        return "Custmer Deleted Successfully";
                    }
                    else
                    {
                        throw new Exception("Data Not Found");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Data Not Valid");
                }
            }
        }
    }
}
