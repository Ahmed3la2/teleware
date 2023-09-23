using AutoMapper;
using TeleWareAssessment.DTOs;
using TeleWareAssessment.Entities;

namespace TeleWare.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();
        }
    }
}
