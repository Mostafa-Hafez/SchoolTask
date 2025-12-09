using MediatR;

namespace School.Application.Students.Commans.DeleteStudent
{
    public record DeleteStudentCommand(int Id) : IRequest<bool>;

}
