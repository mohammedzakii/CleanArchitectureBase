using FluentValidation;
namespace CleanArchitectureBase.Application.Customers.Commands.Create
{
    public class AddNewCustomersCommandValidator : AbstractValidator<AddNewCustomerCommand>
    {
        public AddNewCustomersCommandValidator()
        {
            //Just Example
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Name Must Be Longer than 3 Characters");

            RuleFor(a => a.Phone).NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^[0-9]{11}$").WithMessage("Phone number must be 11 numeric characters.");

            RuleFor(a => a.Email).NotEmpty().WithMessage("Eamil is required.")
                .EmailAddress().WithMessage("Invalid Email Format.");
        }
    }
}
