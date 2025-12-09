using AutoMapper;
using School.Application.DTOs.StudentDTOs;
using School.Domain.Entities;

namespace School.Application.Maping
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(x => x.className, o => o.MapFrom(z => z.Class.Name));
        }
    }
}
