using EmployeeApi.Application.Models;
using MediatR;
public record DeleteEmployeeCommand(int Id) : IRequest;