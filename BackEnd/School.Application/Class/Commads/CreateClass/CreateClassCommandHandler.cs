using MediatR;
using School.Application.Interfaces;

namespace School.Application.Courses.Commads.CreateCourse
{
    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, int>
    {
        private readonly IClassRepository _repo;

        public CreateClassCommandHandler(IClassRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            var cls = new Domain.Entities.Class
            {
                Name = request.Name
               ,
                TeacherName = request.TeacherName
            };

            await _repo.AddAsync(cls);
            return cls.Id;
        }
    }

}
