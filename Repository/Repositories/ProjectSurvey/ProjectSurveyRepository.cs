using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repositories 
{
    public class ProjectSurveyRepository : RepositoryBase<ProjectSurvey>, IProjectSurveyRepository
    {
        public ProjectSurveyRepository(TechnologyStackContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateProjectSurvey(ProjectSurvey projectSurvey)
        {
            foreach(Technology tec in projectSurvey.Technologies)
            this.TechnologyStackContext.Technologies.Attach(tec);

            Create(projectSurvey);
        }

        public void DeleteProjectSurvey(ProjectSurvey ProjectSurvey)
        {
            Delete(ProjectSurvey);
        }

        public async Task<IEnumerable<ProjectSurvey>> GetProjectSurveyAndRelatedDataByForProjectIdAsync(int projectId)
        {
            return await FindByCondition(sr => sr.ProjectId.Equals(projectId)).Include(sr => sr.Technologies).Include(sr => sr.ProjectOwners)
                .Include(sr => sr.Platform).Include(sr => sr.Project).ThenInclude(it => it.Company).ToListAsync();


        }

        public async Task<ProjectSurvey> GetProjectSurveyAndRelatedDataByIdAsync(int projectSurveyId)
        {
            return await this.TechnologyStackContext.ProjectSurveys.Include(sr => sr.Technologies).Include(sr => sr.ProjectOwners)
                .Where(sr => sr.ProjectSurveyId == projectSurveyId)
                .FirstOrDefaultAsync();
        }

        public async Task<ProjectSurvey> GetProjectSurveyByIdAsync(int projectSurveyId)
        {
            return await FindByCondition(sr => sr.ProjectSurveyId.Equals(projectSurveyId))
                .FirstOrDefaultAsync();
        }

        public void UpdateProjectSurvey(ProjectSurvey projectSurvey)
        {
            //var local = this.TechnologyStackContext.ProjectSurveys.Local.FirstOrDefault(entry => entry.ProjectSurveyId == projectSurvey.ProjectSurveyId);
            //if (local != null)
            //{
            //    //this.TechnologyStackContext.Entry<ProjectSurvey>. = local;
            //}

            this.TechnologyStackContext.ChangeTracker.Clear();

            foreach (Technology tec in projectSurvey.Technologies)
                this.TechnologyStackContext.Technologies.Attach(tec);

            Update(projectSurvey);
        }
    }
}
