using AutoMapper;
using AspNetCoreAPI_Jwt_Bearer.Entities;
using AspNetCoreMvc_Jwt_Bearer.Models;


namespace AspNetCoreMvc_Jwt_Bearer.Mapping
{
    public class MappingProfile  : Profile
    {
        public MappingProfile()
        {

            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }

    }
}
