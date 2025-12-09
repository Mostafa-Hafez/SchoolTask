
namespace School.Application.Interfaces
{
    public interface IClassRepository
    {
        Task<Domain.Entities.Class?> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Entities.Class>> GetAllAsync();
        Task<IEnumerable<Domain.Entities.Class>> GetPagedAsync(int pageNumber, int pageSize, string classname, string techername);
        Task AddAsync(Domain.Entities.Class cls);
        Task UpdateAsync(Domain.Entities.Class cls);
        Task DeleteAsync(Domain.Entities.Class cls);
    }
}
