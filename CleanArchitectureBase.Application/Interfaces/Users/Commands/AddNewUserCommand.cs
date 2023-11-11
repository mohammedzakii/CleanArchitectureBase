using MediatR;

namespace CleanArchitectureBase.Application.Interfaces.Users.Commands
{
    public class AddNewUserCommand : IRequest<int>
    {
        public string name { get; set; }
        public class Handler : IRequestHandler<AddNewUserCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
            {

                try
                {
                    return 1;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

    }
}
