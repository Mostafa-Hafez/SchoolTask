using FluentValidation;
using School.Application.Courses.Commads.CreateCourse;

namespace School.Application.Validator
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters").
                MaximumLength(14).WithMessage("Name mustn,t be at more than 14 characters");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MinimumLength(7).WithMessage("Description must be at least 7 characters").
                MaximumLength(150).WithMessage("Description mustn't be at more than 150 characters");

        }
    }
}
