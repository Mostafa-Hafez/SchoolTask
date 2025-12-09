using MediatR;
using School.Application.DTOs.ClassDTOs;

namespace School.Application.Class.Queries.GetClassById
{
    public record GetClassByIdQuery(int Id) : IRequest<ClassDTO>;

}
