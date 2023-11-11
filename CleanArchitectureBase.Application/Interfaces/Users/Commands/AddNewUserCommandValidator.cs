using FluentValidation;

namespace CleanArchitectureBase.Application.Interfaces.Users.Commands
{
    public class AddNewUserCommandValidator : AbstractValidator<AddNewUserCommand>
    {
        public AddNewUserCommandValidator()
        {
            //Just Example
           RuleFor(a => a.name).NotEmpty().WithMessage("Eamil is required.");
        }
    }
}
