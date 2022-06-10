using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repositories
{
    public interface IProjectSurveyRepository
    {
        Task<ProjectSurvey> GetProjectSurveyAndRelatedDataByIdAsync(int projectSurveyId);

        Task<IEnumerable<ProjectSurvey>> GetProjectSurveyAndRelatedDataByForProjectIdAsync(int projectId);

        Task<ProjectSurvey> GetProjectSurveyByIdAsync(int projectSurveyId);
        void CreateProjectSurvey(ProjectSurvey projectSurvey);
        void UpdateProjectSurvey(ProjectSurvey projectSurvey);
        void DeleteProjectSurvey(ProjectSurvey ProjectSurvey);
    }
}
