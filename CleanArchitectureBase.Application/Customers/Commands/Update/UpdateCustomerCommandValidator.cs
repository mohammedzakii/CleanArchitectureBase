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
                .WithMessage("Name Must Be Longer than 3 Characters");

            RuleFor(a => a.Phone).Matches(@"^[0-9]{11}$")
                .When(user => !string.IsNullOrEmpty(user.Phone))
                .WithMessage("Phone number must be 11 numeric characters.");

            RuleFor(a => a.Email).EmailAddress()
                .When(user => !string.IsNullOrEmpty(user.Email)).WithMessage("Invalid Email Format.");
        }
    }
}
