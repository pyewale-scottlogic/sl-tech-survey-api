using Repository.Models;

namespace Repository.Repositories
{
    public interface IProjectOwnerRepository
    {
        Task<IEnumerable<ProjectOwner>> GetAllProjectOwnersAsync();
        Task<ProjectOwner> GetProjectOwnerAsync(int projectOwnerId);
        Task<IEnumerable<ProjectOwner>> GetProjectOwnersByProjectId(int ProjectId);
        void CreateProjectOwner(ProjectOwner ProjectOwner);
        void UpdateProjectOwner(ProjectOwner ProjectOwner);
        void DeleteProjectOwner(ProjectOwner ProjectOwner);
    }
}
