using FluentValidation;
using School.Application.Courses.Commads.UpdateCourse;

namespace School.Application.Validator
{
    internal class UpdateCourseValidator: AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseValidator()
        {
          RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters").
                 MaximumLength(14).WithMessage("Name mustn,t be at more than 14 characters");
            RuleFor(x => x.Discription)
                 .NotEmpty().WithMessage("Discription is required")
                 .MinimumLength(7).WithMessage("Discription must be at least 7 characters").
                 MaximumLength(150).WithMessage("Discription mustn't be at more than 150 characters");

        }
    }
}
