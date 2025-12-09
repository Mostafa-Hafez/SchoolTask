using MediatR;
using School.Application.DTOs.CourseDTOs;

namespace School.Application.Courses.Queries.GetClasses
{
    public record GetCoursesQuery(int PageNumber, int PageSize,string coursename, string description) : IRequest<IEnumerable<CourseDTO>>;

}
