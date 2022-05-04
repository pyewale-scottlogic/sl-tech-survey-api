using TechSurveyAPI.Models;

namespace TechSurveyAPI.Repositories
{
    public interface IProjectOwnerRepository
    {
        Task<IEnumerable<ProjectOwner>> GetAllProjectOwnersAsync();
        Task<ProjectOwner> GetProjectOwnerByProjectSurveyIdAsync(int ProjectSurveyId);
        void CreateProjectOwner(ProjectOwner ProjectOwner);
        void UpdateProjectOwner(ProjectOwner ProjectOwner);
        void DeleteProjectOwner(ProjectOwner ProjectOwner);
    }
}
