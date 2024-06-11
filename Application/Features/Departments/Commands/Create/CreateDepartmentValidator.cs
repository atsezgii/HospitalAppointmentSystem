using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.Create
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentValidator()
        {

            RuleFor(x => x.DepartmentName)
              .NotEmpty().WithMessage("Department Name is required.")
              .MinimumLength(2).WithMessage("Department Name cannot be shorter than 2 characters.")
              .MaximumLength(50).WithMessage("Department Name cannot be longer than 50 characters.");

            RuleFor(x => x.DepartmentDescription)
                .NotEmpty().WithMessage("Department Description is required.")
                .MinimumLength(2).WithMessage("Department Description cannot be shorter than 2 characters.")
                .MaximumLength(50).WithMessage("Department Description cannot be longer than 250 characters.");

        }
    }
}
