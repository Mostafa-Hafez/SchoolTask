using MediatR;
using School.Application.DTOs.StudentDTOs;
using School.Application.Response;

namespace School.Application.Students.Queries.GetStudents
{
    public class GetStudentsQuery : IRequest<PagedResult<StudentDTO>>
    {
        public string? Name { get; set; }
        public string? ClassName { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
