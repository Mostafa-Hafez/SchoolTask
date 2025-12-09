using MediatR;
using School.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Courses.Commads.UpdateCourse
{
    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, bool>
    {
        private readonly IClassRepository _repo;

        public UpdateClassCommandHandler(IClassRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            var cls = await _repo.GetByIdAsync(request.Id);
            if (cls == null) return false;

            cls.Name = request.Name;
            cls.TeacherName = request.TeacherName;
            await _repo.UpdateAsync(cls);
            return true;
        }
    }

}
