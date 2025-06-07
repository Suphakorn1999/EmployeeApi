using AutoMapper;
using EmployeeApi.Application.Models;
using EmployeeApi.Application.Queries;
using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Interfaces;
using MediatR;

namespace EmployeeApi.Application.Handlers
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, PagedResult<EmployeeDtoRes>>
    {
        private readonly IEmployeeRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeesHandler(IEmployeeRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<EmployeeDtoRes>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            PagedResult<EmployeeDtoRes> pagedResult = new PagedResult<EmployeeDtoRes>();

            pagedResult = new PagedResult<EmployeeDtoRes>
            {
                data = _mapper.Map<List<EmployeeDtoRes>>(await _repository.GetAllAsync(request.PageNumber, request.PageSize)),
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = await _repository.GetCountAsync()
            };

            return pagedResult;
        }
    }
}
