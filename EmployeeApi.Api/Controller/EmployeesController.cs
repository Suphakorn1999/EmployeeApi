using EmployeeApi.Application.Queries;
using EmployeeApi.Application.Commands;
using EmployeeApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Application.Models;

namespace EmployeeApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApiResponse response = new ApiResponse();
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployees(int PageNumber, int PageSize)
        {
            PagedResult<EmployeeDtoRes> result = await _mediator.Send(new GetAllEmployeesQuery(PageNumber, PageSize));
            return Ok(response.SuccessResponse(result));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEmployee(EmployeeDtoReq employee)
        {
            await _mediator.Send(new CreateEmployeeCommand(employee));
            return Ok(response.SuccessResponse());
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            EmployeeDtoRes result = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return Ok(response.SuccessResponse(result));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateEmployee(int Id, EmployeeDtoReq Employee)
        {
            await _mediator.Send(new UpdateEmployeeCommand(Id, Employee));
            return Ok(response.SuccessResponse());
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return Ok(response.SuccessResponse());
        }
    }
}
