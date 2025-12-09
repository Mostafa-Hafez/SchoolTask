using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.DTOs.StudentDTOs;
using School.Application.Interfaces;
using School.Application.Response;

namespace School.Application.Students.Queries.GetStudents
{
    public class GetStudentsHandler
    : IRequestHandler<GetStudentsQuery, PagedResult<StudentDTO>>
    {
        private readonly ISchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentsHandler(ISchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<StudentDTO>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Students.Include(z => z.Class).AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(s => s.Name.Contains(request.Name));

            if (!string.IsNullOrEmpty(request.ClassName))
                query = query.Where(s => s.Class != null && s.Class.Name.Contains(request.ClassName));

           
            var totalCount = await query.CountAsync(cancellationToken);

            var students = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            
            var mapped = _mapper.Map<List<StudentDTO>>(students);

            return new PagedResult<StudentDTO>
            {
                Items = mapped,
                TotalCount = totalCount
            };
        }
    }


}
