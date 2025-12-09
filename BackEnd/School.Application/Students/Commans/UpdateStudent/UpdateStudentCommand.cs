using MediatR;

namespace School.Application.Students.Commans.UpdateStudent
{
    public class UpdateStudentCommand
     : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public int UserId { get; set; }
    }
}
