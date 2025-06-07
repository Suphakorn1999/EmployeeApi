using EmployeeApi.Application.Handlers;
using EmployeeApi.Application.Mappings;
using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Interfaces;
using EmployeeApi.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepository>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddValidatorsFromAssemblyContaining<CreateEmployeeValidator>();
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddControllers();

        builder.Services.AddMediatR(typeof(CreateEmployeeHandler).Assembly);
        builder.Services.AddMediatR(typeof(DeleteEmployeeCommandHandler).Assembly);
        builder.Services.AddMediatR(typeof(UpdateEmployeeHandler).Assembly);
        builder.Services.AddMediatR(typeof(GetAllEmployeesHandler).Assembly);
        builder.Services.AddMediatR(typeof(GetEmployeeByIdHandler).Assembly);

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
