using MediatR;
using School.Application.Interfaces;

namespace School.Application.Students.Commans.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentRepository _studentrepo;

        public DeleteStudentCommandHandler(IStudentRepository studentrepo)
        {
            _studentrepo = studentrepo;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _studentrepo.GetByIdAsync(request.Id);

            if (entity == null)
                return false;
            await _studentrepo.DeleteAsync(entity);

            return true;
        }
    }
}
