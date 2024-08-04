using API.Entities;
using API.Models;
using AutoMapper;

namespace API
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();

        }
    }
}
