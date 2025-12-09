using FluentValidation;
using School.Application.Courses.Commads.UpdateCourse;

namespace School.Application.Validator
{
    internal class UpdateClassValidator: AbstractValidator<UpdateClassCommand>
    {
        public UpdateClassValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters").
                MaximumLength(14).WithMessage("Name mustn,t be at more than 14 characters");
            
            RuleFor(x => x.TeacherName)
                .NotEmpty().WithMessage("TeacherName is required")
                .MinimumLength(3).WithMessage("TeacherName must be at least 3 characters").
                MaximumLength(14).WithMessage("TeacherName mustn,t be at more than 14 characters");


        }
    }
}
