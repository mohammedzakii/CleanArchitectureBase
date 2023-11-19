using CleanArchitectureBase.Application.Customers.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("Id is required.")
                .Must(id => int.TryParse(id.ToString(), out _)).WithMessage("Id must be Number.");
            //Just Example

            RuleFor(a => a.Name)
                .MinimumLength(3).When(user => !string.IsNullOrEmpty(user.Name))
                .WithMessage("Name Must Be Longer than 3 Characters")
                .Must(name => !string.IsNullOrWhiteSpace(name.Trim())).WithMessage("Name cannot contain white spaces."); ;

            RuleFor(a => a.Phone).Matches(@"^[0-9]{11}$")
                .When(user => !string.IsNullOrEmpty(user.Phone))
                .WithMessage("Phone number must be 11 numeric characters.")
                .Must(Phone => !string.IsNullOrWhiteSpace(Phone.Trim())).WithMessage("Phone cannot contain white spaces.");

            RuleFor(a => a.Email).EmailAddress()
                .When(user => !string.IsNullOrEmpty(user.Email)).WithMessage("Invalid Email Format.")
                .Must(Email => !string.IsNullOrWhiteSpace(Email.Trim())).WithMessage("Email cannot contain white spaces."); ;
        }
    }
}
