using MediatR;
using School.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Courses.Commads.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly ICourseRepository _repo;

        public DeleteCourseCommandHandler(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _repo.GetByIdAsync(request.Id);
            if (course == null) return false;

            await _repo.DeleteAsync(course);
            return true;
        }
    }

}
