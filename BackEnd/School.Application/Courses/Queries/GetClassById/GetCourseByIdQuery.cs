using MediatR;
using School.Application.DTOs.CourseDTOs;

namespace School.Application.Courses.Queries.GetClassById
{
    public record GetCourseByIdQuery(int Id) : IRequest<CourseDTO>;

}
