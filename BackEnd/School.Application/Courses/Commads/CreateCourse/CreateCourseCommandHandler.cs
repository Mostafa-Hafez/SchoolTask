using MediatR;
using School.Application.Interfaces;
using School.Domain.Entities;

namespace School.Application.Courses.Commads.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly ICourseRepository _repo;

        public CreateCourseCommandHandler(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course
            { Description=request.Description, Name=request.Name
            };

            await _repo.AddAsync(course);
            return course.Id;
        }
    }

}
