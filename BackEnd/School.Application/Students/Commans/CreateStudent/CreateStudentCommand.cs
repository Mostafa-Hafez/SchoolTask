using MediatR;

namespace School.Application.Students.Commans.CreateStudent
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
    }
}
