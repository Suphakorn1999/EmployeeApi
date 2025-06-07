using AutoMapper;
using EmployeeApi.Application.Models;
using EmployeeApi.Domain.Common.Exceptions;
using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Interfaces;
using MediatR;


namespace EmployeeApi.Application.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDtoRes>
    {
        private readonly IEmployeeRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDtoRes> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            Employee? employee = await _repository.GetByIdAsync(request.Id);

            if (employee == null)
            {
                throw new NotFoundException("Employee", request.Id);
            }
                
            EmployeeDtoRes result = _mapper.Map<EmployeeDtoRes>(employee);

            return result;
        }
    }
}
