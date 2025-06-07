using EmployeeApi.Application.Models;
using MediatR;

namespace EmployeeApi.Application.Commands
{
    public class CreateEmployeeCommand : IRequest
    {
        public EmployeeDtoReq Employee { get; set; }
        public CreateEmployeeCommand(EmployeeDtoReq employee)
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee), "Employee cannot be null");
        }
    }
}
