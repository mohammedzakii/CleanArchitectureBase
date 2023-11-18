using FluentValidation;
namespace CleanArchitectureBase.Application.Customers.Commands.Create
{
    public class AddNewCustomersCommandValidator : AbstractValidator<AddNewCustomerCommand>
    {
        public AddNewCustomersCommandValidator()
        {
            //Just Example
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Max Lenth is 50")
                .MinimumLength(3).WithMessage("Name Must Be Longer than 3 Characters")
                .Must(name => !string.IsNullOrWhiteSpace(name.Trim())).WithMessage("Name cannot contain white spaces.");

            RuleFor(a => a.Phone).NotEmpty().WithMessage("Phone is required.")
                .MaximumLength(50).WithMessage("Max Lenth is 50")
                .Matches(@"^[0-9]{11}$").WithMessage("Phone number must be 11 numeric characters.")
                .Must(Phone => !string.IsNullOrWhiteSpace(Phone.Trim())).WithMessage("Phone cannot contain white spaces.");

            RuleFor(a => a.Email).NotEmpty().WithMessage("Eamil is required.")
                .MaximumLength(50).WithMessage("Max Lenth is 50")
                .EmailAddress().WithMessage("Invalid Email Format.")
                .Must(Email => !string.IsNullOrWhiteSpace(Email.Trim())).WithMessage("Email cannot contain white spaces.");
        }
    }
}
