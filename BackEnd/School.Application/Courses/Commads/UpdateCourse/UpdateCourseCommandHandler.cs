using MediatR;
using School.Application.Interfaces;

namespace School.Application.Courses.Commads.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly ICourseRepository _repo;

        public UpdateCourseCommandHandler(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _repo.GetByIdAsync(request.Id);
            if (course == null) return false;

            course.Name = request.Name;
            course.Description = request.Discription;

            await _repo.UpdateAsync(course);
            return true;
        }
    }

}
