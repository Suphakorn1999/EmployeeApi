using EmployeeApi.Application.Models;
using EmployeeApi.Domain.Common.Exceptions;
using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Interfaces;
using MediatR;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeRepository<Employee> _repository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository<Employee> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee? employee = await _repository.GetByIdAsync(request.Id);
        if (employee == null || employee.IsDeleted)
            throw new NotFoundException("Employee", request.Id);

        int result = await _repository.DeleteAsync(employee);
        if (result <= 0)
            throw new Exception("Failed to delete employee. Please try again later.");
        return Unit.Value;
    }
}
