using FluentValidation;
using School.Application.Students.Commans.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Validator
{
    public class CreateStudentValidator: AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Name is required")
        .MinimumLength(3).WithMessage("Name must be at least 3 characters").
        MaximumLength(14).WithMessage("Name mustn,t be at more than 14 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$") 
               .WithMessage("Email format is invalid"); 

            RuleFor(x => x.ClassId)
                .GreaterThan(0).WithMessage("ClassId must be valid");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be valid");
        }
    }
}
