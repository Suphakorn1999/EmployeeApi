using EmployeeApi.Domain.Entities;

namespace EmployeeApi.Domain.Interfaces
{
    public interface IEmployeeRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(int PageNumber, int PageSize);
        Task<T?> GetByIdAsync(int id);
        Task<string?> GetMaxEmpNoAsync();
        Task<int> GetCountAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}