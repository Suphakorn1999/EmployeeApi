using AutoMapper;
using EmployeeApi.Domain.Common.Exceptions;
using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Interfaces;
using MediatR;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeRepository<Employee> _repository;
    private readonly IMapper _mapper;

    public UpdateEmployeeHandler(IEmployeeRepository<Employee> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee? employee = await _repository.GetByIdAsync(request.Id);

        if (employee == null)
            throw new NotFoundException("Employee", request.Id);

        employee = _mapper.Map<EmployeeDtoReq , Employee>(request.Employee, employee);

        await _repository.UpdateAsync(employee);
        return Unit.Value;
    }
}

