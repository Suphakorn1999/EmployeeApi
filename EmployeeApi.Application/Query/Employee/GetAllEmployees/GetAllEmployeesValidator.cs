using EmployeeApi.Application.Models;
using EmployeeApi.Domain.Entities;
using FluentValidation;

public class GetAllEmployeesValidator : AbstractValidator<PagedResult<EmployeeDtoReq>>
{
    public GetAllEmployeesValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
    }
}
