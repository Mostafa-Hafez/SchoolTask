using AutoMapper;
using MediatR;
using School.Application.DTOs.ClassDTOs;
using School.Application.Interfaces;

namespace School.Application.Class.Queries.GetClassById
{
    public class GetClassByIdQueryHandler : IRequestHandler<GetClassByIdQuery, ClassDTO>
    {
        private readonly IClassRepository _repo;
        private readonly IMapper _mapper;

        public GetClassByIdQueryHandler(IClassRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ClassDTO> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
        {
            var cls = await _repo.GetByIdAsync(request.Id);
            return _mapper.Map<ClassDTO>(cls);
        }
    }

}
