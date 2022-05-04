using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repositories
{
    public class ProjectOwnerRepository : RepositoryBase<ProjectOwner>, IProjectOwnerRepository
    {
        public ProjectOwnerRepository(TechnologyStackContext repositoryContext)
           : base(repositoryContext)
        {
        }
        public void CreateProjectOwner(ProjectOwner projectOwner)
        {
            Create(projectOwner);
        }

        public void DeleteProjectOwner(ProjectOwner projectOwner)
        {
            Delete(projectOwner);
        }

        public void UpdateProjectOwner(ProjectOwner projectOwner)
        {
            Update(projectOwner);

        }
        public async Task<IEnumerable<ProjectOwner>> GetAllProjectOwnersAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.AccountOwner.FirstName)
               .ToListAsync();
        }

        public async Task<ProjectOwner> GetProjectOwnerByProjectSurveyIdAsync(int projectSurveyId)
        {
            return await FindByCondition(projectOwner => projectOwner.ProjectSurveyId.Equals(projectSurveyId))
                 .FirstOrDefaultAsync();
        }
    }
}
