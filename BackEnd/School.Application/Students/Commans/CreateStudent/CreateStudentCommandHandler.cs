using MediatR;
using School.Application.Interfaces;
using School.Domain.Entities;

namespace School.Application.Students.Commans.CreateStudent
{
    public class CreateStudentCommandHandler
    : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepo;

        public CreateStudentCommandHandler(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Student
            {
                Name = request.Name,
                Email = request.Email,
                ClassId = request.ClassId
            };
            await _studentRepo.AddAsync(entity);

            return entity.Id;
        }
    }
}
