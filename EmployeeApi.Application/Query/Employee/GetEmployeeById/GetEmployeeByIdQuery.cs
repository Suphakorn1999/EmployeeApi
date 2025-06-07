using EmployeeApi.Application.Models;
using EmployeeApi.Domain.Entities;
using MediatR;
public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDtoRes>;
