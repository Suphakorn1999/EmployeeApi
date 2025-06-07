using EmployeeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
