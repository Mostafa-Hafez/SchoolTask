using FluentValidation;
using School.Application.Students.Commans.UpdateStudent;

namespace School.Application.Validator
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentValidator()
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
        }
    }
}
