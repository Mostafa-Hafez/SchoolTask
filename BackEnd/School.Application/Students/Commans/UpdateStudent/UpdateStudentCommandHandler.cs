using MediatR;
using School.Application.Interfaces;

namespace School.Application.Students.Commans.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentRepository _studentrepo;

        public UpdateStudentCommandHandler(IStudentRepository studentrepo)
        {
            _studentrepo = studentrepo;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _studentrepo.GetByIdAsync(request.Id);

            if (entity == null)
                return false;

            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.ClassId = request.ClassId;
            await _studentrepo.UpdateAsync(entity);

            return true;
        }
    }

}
