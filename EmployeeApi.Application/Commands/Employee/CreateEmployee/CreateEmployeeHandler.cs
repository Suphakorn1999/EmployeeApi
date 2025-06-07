using AutoMapper;
using EmployeeApi.Application.Commands;
using EmployeeApi.Application.Models;
using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Interfaces;
using MediatR;

namespace EmployeeApi.Application.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IEmployeeRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _mapper.Map<Employee>(request.Employee);

            string EmpNo = await _repository.GetMaxEmpNoAsync() ?? "1000";
            employee.EmpNo = (int.Parse(string.IsNullOrEmpty(EmpNo) ? "1000" : EmpNo) + 1).ToString();
            employee.HireDate = DateTime.UtcNow;

            await _repository.AddAsync(employee);

            return Unit.Value;
        }
    }
}
