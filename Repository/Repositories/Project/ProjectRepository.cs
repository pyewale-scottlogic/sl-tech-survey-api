using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(TechnologyStackContext repositoryContext)
           : base(repositoryContext)
        {
        }
        public void CreateProject(Project project)
        {
            Create(project);
        }

        public void DeleteProject(Project project)
        {
            Delete(project);
        }

        public void UpdateProject(Project project)
        {
            Update(project);

        }
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await TechnologyStackContext.Projects.Include(pr => pr.Company).OrderBy(ow => ow.ProjectName).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            return await FindByCondition(project => project.ProjectId.Equals(projectId))
                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjectsForCompanyAsync(int CompnayId)
        {
            return await FindByCondition(project => project.CompanyId.Equals(CompnayId)).
                Include(pr => pr.Company).
                Include(pr => pr.ProjectOwners).ThenInclude(po => po.AccountOwner).
                Include(pr => pr.ProjectOwners).ThenInclude(po => po.TechLead).
                OrderBy(ow => ow.ProjectName).ToListAsync();
        }
    }
}
