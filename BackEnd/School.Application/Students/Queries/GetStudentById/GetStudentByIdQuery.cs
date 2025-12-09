using MediatR;
using School.Application.DTOs.StudentDTOs;

namespace School.Application.Students.Queries.GetStudentById
{
    public record GetStudentByIdQuery(int Id) : IRequest<StudentDTO>;


}
