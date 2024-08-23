using API.Entities;
using API.Models;
using AutoMapper;

namespace API
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(m => m.PeoplePartner, c => c.MapFrom(p => p.PeoplePartner != null ? new PeoplePartnerDto
                {
                    ID = p.PeoplePartner.ID,
                    FullName = p.PeoplePartner.FullName,
                    Subdivision = p.PeoplePartner.Subdivision,
                    Position = p.PeoplePartner.Position,
                    Status = p.PeoplePartner.Status,
                    Photo = p.PeoplePartner.Photo
                } : null));

            CreateMap<CreateEmployeeDto, Employee>();

        }
    }
}
