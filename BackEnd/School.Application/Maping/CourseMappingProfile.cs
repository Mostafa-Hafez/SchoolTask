using AutoMapper;
using School.Application.DTOs.CourseDTOs;
using School.Domain.Entities;

namespace School.Application.Maping
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDTO>();
        }
    }
}
