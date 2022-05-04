using TechSurveyAPI.Models;
namespace TechSurveyAPI.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int ProjectId);
        void CreateProject(Project Project);
        void UpdateProject(Project Project);
        void DeleteProject(Project Project);
    }
}
