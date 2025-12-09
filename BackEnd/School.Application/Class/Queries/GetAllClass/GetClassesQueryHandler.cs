using AutoMapper;
using MediatR;
using School.Application.DTOs.ClassDTOs;
using School.Application.Interfaces;

namespace School.Application.Class.Queries.GetAllClass
{
    public class GetClassesQueryHandler : IRequestHandler<GetClassesQuery, IEnumerable<ClassDTO>>
    {
        private readonly IClassRepository _repo;
        private readonly IMapper _mapper;

        public GetClassesQueryHandler(IClassRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassDTO>> Handle(GetClassesQuery request, CancellationToken cancellationToken)
        {
            var clss = await _repo.GetPagedAsync(request.PageNumber, request.PageSize, request.classname, request.techername);
            return _mapper.Map<IEnumerable<ClassDTO>>(clss);
        }
    }

}
