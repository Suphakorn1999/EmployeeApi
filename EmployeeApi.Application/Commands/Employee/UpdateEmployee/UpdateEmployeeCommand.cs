using EmployeeApi.Domain.Entities;
using MediatR;

public record UpdateEmployeeCommand(int Id, EmployeeDtoReq employee) : IRequest
{
    public EmployeeDtoReq Employee { get; set; } = employee;
    public int Id { get; set; } = Id;
};