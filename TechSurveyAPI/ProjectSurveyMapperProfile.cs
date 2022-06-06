using AutoMapper;
using TechSurveyAPI.DTOs;
using Repository.Models;
namespace TechSurveyAPI
{
    public class ProjectSurveyMapperProfile : Profile
    {
        public ProjectSurveyMapperProfile()
        {
            #region ProjectSurvey
            CreateMap<ProjectSurvey, ProjectSurveyDTO>().PreserveReferences();

            CreateMap<ProjectSurveyAddDTO, ProjectSurvey>();

            CreateMap<ProjectSurveyUpdateDTO, ProjectSurvey>();
            #endregion ProjectSurvey
        }
    }
}
