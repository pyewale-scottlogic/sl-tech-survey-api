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

            #region Project
            CreateMap<Project, ProjectDTO>();

            CreateMap<ProjectAddDTO, Project>();

            CreateMap<ProjectUpdateDTO, Project>();
            #endregion Project

            #region Employee
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<EmployeeAddDTO, Employee>();

            CreateMap<EmployeeUpdateDTO, Employee>();
            #endregion Employee

            #region Platform
            CreateMap<Platform, PlatformDTO>();

            CreateMap<PlatformAddDTO, Platform>();

            CreateMap<PlatformUpdateDTO, Platform>();

            CreateMap<PlatformDTO, Platform>();
            #endregion Platform


            #region Technology
            CreateMap<Technology, TechnologyDTO>().PreserveReferences();

            CreateMap<TechnologyAddDTO, Technology>();

            CreateMap<TechnologyUpdateDTO, Technology>();

            CreateMap<TechnologyDTO, Technology>();
            #endregion Technology

            #region ProjectSurvey
            CreateMap<ProjectSurvey, ProjectSurveyDTO>().PreserveReferences();

            CreateMap<ProjectSurveyAddDTO, ProjectSurvey>();

            CreateMap<ProjectSurveyUpdateDTO, ProjectSurvey>();
            #endregion ProjectSurvey


            #region ProjectOwner
            CreateMap<ProjectOwner, ProjectOwnerDTO>().PreserveReferences();

            CreateMap<ProjectOwnerAddDTO, ProjectOwner>().PreserveReferences();

            CreateMap<ProjectOwnerUpdateDTO, ProjectOwner>();

            CreateMap<ProjectOwnerDTO, ProjectOwner>();
            #endregion ProjectOwner
        }

    }
}
