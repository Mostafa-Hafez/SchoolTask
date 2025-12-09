using AutoMapper;
using MediatR;
using School.Application.DTOs.CourseDTOs;
using School.Application.Interfaces;

namespace School.Application.Courses.Queries.GetClasses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseDTO>>
    {
        private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(ICourseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var classes = await _repo.GetPagedAsync(request.PageNumber, request.PageSize,request.coursename,request.description);
            return _mapper.Map<IEnumerable<CourseDTO>>(classes);
        }
    }

}
