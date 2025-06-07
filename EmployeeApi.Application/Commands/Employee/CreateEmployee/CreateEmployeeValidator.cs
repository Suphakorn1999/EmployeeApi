using FluentValidation;

public class CreateEmployeeValidator : AbstractValidator<EmployeeDtoReq>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Salary).GreaterThan(0);

        RuleFor(x => x.Designation).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Comm).GreaterThanOrEqualTo(0).When(x => x.Comm.HasValue);
        RuleFor(x => x.DeptNo).GreaterThan(0);
    }
}