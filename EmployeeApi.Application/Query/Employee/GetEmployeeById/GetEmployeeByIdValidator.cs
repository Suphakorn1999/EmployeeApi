using EmployeeApi.Domain.Entities;
using FluentValidation;

public class GetEmployeeByIdValidator : AbstractValidator<Employee>
{
    public GetEmployeeByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Employee ID must be greater than 0.");
    }
}
