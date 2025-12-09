using MediatR;
using School.Application.DTOs.ClassDTOs;

namespace School.Application.Class.Queries.GetAllClass
{
    public record GetClassesQuery(int PageNumber, int PageSize, string classname, string techername) : IRequest<IEnumerable<ClassDTO>>;

}
