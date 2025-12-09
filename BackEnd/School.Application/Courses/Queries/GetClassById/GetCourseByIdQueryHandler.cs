using AutoMapper;
using MediatR;
using School.Application.DTOs.CourseDTOs;
using School.Application.Interfaces;

namespace School.Application.Courses.Queries.GetClassById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDTO>
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;

        public GetCourseByIdQueryHandler(ICourseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CourseDTO> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var clas = await _repo.GetByIdAsync(request.Id);
            return _mapper.Map<CourseDTO>(clas);
        }
    }

}
