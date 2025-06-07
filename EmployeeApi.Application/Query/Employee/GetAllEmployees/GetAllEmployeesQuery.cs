using EmployeeApi.Application.Models;
using EmployeeApi.Domain.Entities;
using MediatR;

namespace EmployeeApi.Application.Queries
{
    public class GetAllEmployeesQuery : IRequest<PagedResult<EmployeeDtoRes>>
    {
        public int PageNumber { get; }
        public int PageSize { get; }

        public GetAllEmployeesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
