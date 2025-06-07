using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Interfaces;
using EmployeeApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository<Employee>
{
    private readonly AppDbContext _context;
    public EmployeeRepository(AppDbContext context) => _context = context;

    public async Task<IQueryable<Employee>> GetAllAsync(int PageNumber, int PageSize)
    {
        IQueryable<Employee> employees = _context.Employees.AsQueryable();

        if (PageNumber > 0 && PageSize > 0)
        {
            employees = employees
                .Where(w => w.IsDeleted == false)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize);
        }

        return await Task.FromResult(employees);
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees.FirstOrDefaultAsync(w => w.Id == id && !w.IsDeleted);
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.Employees.CountAsync();
    }

    public async Task<string?> GetMaxEmpNoAsync()
    {
        Employee? employee = await _context.Employees
                                    .OrderByDescending(e => e.EmpNo)
                                    .FirstOrDefaultAsync();
        return employee == null ? string.Empty : employee.EmpNo;
    }

    public async Task AddAsync(Employee entity)
    {
        await _context.Employees.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee entity) 
    {
        _context.Employees.Update(entity);
        await _context.SaveChangesAsync();
    } 

    public async Task<int> DeleteAsync(Employee entity)
    {
        entity.IsDeleted = true;
        entity.deleteDate = DateTime.UtcNow;
        _context.Employees.Update(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }
}
