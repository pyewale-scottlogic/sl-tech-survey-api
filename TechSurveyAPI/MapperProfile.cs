using AutoMapper;
using TechSurveyAPI.DTOs;
using Repository.Models;

namespace TechSurveyAPI
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Company
            CreateMap<Company, CompanyDTO>();

            CreateMap<CompanyAddDTO,Company>();

            CreateMap<CompanyUpdateDTO, Company>();
            #endregion Company

            #region Employee
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<EmployeeAddDTO, Employee>();

            CreateMap<EmployeeUpdateDTO, Employee>();
            #endregion Employee
        }

    }
}
