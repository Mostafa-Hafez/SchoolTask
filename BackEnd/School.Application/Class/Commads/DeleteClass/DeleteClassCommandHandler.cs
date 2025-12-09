using MediatR;
using School.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Courses.Commads.DeleteCourse
{
    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, bool>
    {
        private readonly IClassRepository _repo;

        public DeleteClassCommandHandler(IClassRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            var cls = await _repo.GetByIdAsync(request.Id);
            if (cls == null) return false;

            await _repo.DeleteAsync(cls);
            return true;
        }
    }

}
