using AutoMapper;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<App, AppDTO>();
            CreateMap<User, UserDTO>();

            CreateMap<EmployeeDetail,EmployeeDTO>()
            .ForMember(dest =>
            dest.EmpDetailsID,
            opt => opt.MapFrom(src => src.EmployeeDetailId))
            .ForMember(dest =>
            dest.EmpEmailId,
            opt => opt.MapFrom(src => src.Email))
            .ReverseMap();         


            CreateMap<EmployeeDetail,CreateEmployeeDTO>()
             .ReverseMap();

              CreateMap<ReferenceTbl,ReferenceTblDTO>()
             .ReverseMap();

              CreateMap<Employer,EmployerDTO>()
              .ReverseMap();
        }
    }
}
