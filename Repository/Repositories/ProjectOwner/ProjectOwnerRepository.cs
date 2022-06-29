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

        //public async Task<ProjectOwner> GetProjectOwnerByProjectId(int projectId)
        //{
        //    return await FindByCondition(projectOwner => projectOwner.ProjectId.Equals(projectId))
        //         .FirstOrDefaultAsync();
        //}

        public async Task<ProjectOwner> GetProjectOwnerAsync(int projectOwnerId)
        {
            return await FindByCondition(projectOwner => projectOwner.ProjectOwnerId.Equals(projectOwnerId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProjectOwner>> GetProjectOwnersByProjectId(int ProjectId)
        {
            return await FindByCondition(projectOwner => projectOwner.ProjectId.Equals(ProjectId)).
                Include(po => po.AccountOwner).
                Include(po => po.TechLead).
                Include(po => po.Project)
                .OrderBy(po => po.FromDate).ToListAsync();
        }
    }
}
