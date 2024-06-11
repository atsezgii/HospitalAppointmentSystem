using Application.Features.Auth.Commands.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.Create
{
    
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.Email)
         .NotEmpty().WithMessage("Email is required.")
         .EmailAddress().WithMessage("Invalid Email Address.");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(6, 100).WithMessage("Password must be between 6 and 100 characters.");

            RuleFor(x => x.FirstName)
           .NotEmpty().WithMessage("First Name is required.")
           .MinimumLength(2).WithMessage("First Name cannot be shorter than 2 characters.")
           .MaximumLength(50).WithMessage("First Name cannot be longer than 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MinimumLength(2).WithMessage("Last Name cannot be shorter than 2 characters.")
                .MaximumLength(50).WithMessage("Last Name cannot be longer than 50 characters.");

        }
    }
}
