using AutoMapper;
using EmployeeApi.Domain.Entities;

namespace EmployeeApi.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDtoRes>();
        CreateMap<Employee, EmployeeDtoReq>().ReverseMap();
    }
}