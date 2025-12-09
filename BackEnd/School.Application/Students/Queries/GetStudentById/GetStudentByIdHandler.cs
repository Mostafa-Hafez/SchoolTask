using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.DTOs.StudentDTOs;
using School.Application.Interfaces;

namespace School.Application.Students.Queries.GetStudentById
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDTO>// IRequestHandler<GetStudentByIdQuery, StudentDTO>
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentByIdHandler(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDTO> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students
                .Include(x => x.Class)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return _mapper.Map<StudentDTO>(entity);
        }
    }


}
