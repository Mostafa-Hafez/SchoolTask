using AutoMapper;
using School.Application.DTOs.ClassDTOs;

namespace School.Application.Maping
{
    public class ClassMappingProfile : Profile
    {
        public ClassMappingProfile()
        {
            CreateMap<Domain.Entities.Class, ClassDTO>();
        }

    }
}
