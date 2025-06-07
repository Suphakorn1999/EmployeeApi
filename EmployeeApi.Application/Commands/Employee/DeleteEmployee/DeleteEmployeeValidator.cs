using EmployeeApi.Domain.Entities;
using FluentValidation;

public class DeleteEmployeeValidator : AbstractValidator<Employee>
{
    public DeleteEmployeeValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Employee ID must be greater than 0.");
    }
}