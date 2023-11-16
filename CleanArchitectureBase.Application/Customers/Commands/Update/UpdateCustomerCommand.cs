using CleanArchitectureBase.Domin.Repositories;
using MediatR;

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
            private readonly ICustomerRepository _customerRepository;
            public Handler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                try
                {

                    var customer = await _customerRepository.GetByIdAsync(request.Id);

                    if (customer != null)
                    {

                        if (!string.IsNullOrEmpty(request.Email))
                            customer.Email = request.Email;

                        if (!string.IsNullOrEmpty(request.Phone))
                            customer.Phone = request.Phone;

                        if (!string.IsNullOrEmpty(request.Name))
                            customer.Name = request.Name;

                        await _customerRepository.Update();

                        return "Custmer Updated Successfully";
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
