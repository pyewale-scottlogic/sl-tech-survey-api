using Microsoft.EntityFrameworkCore;
using Repository.Models;


namespace Repository.Repositories
{
    public class SurveyRepository : RepositoryBase<Survey>, ISurveyRepository
    {
        public SurveyRepository(TechnologyStackContext repositoryContext)
           : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Survey>> GetAllSurveysAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Year)
               .ToListAsync();
        }

        public async Task<Survey> GetSurveyByIdAsync(int SurveyId)
        {
            return await FindByCondition(Survey => Survey.SurveyId.Equals(SurveyId))
                .FirstOrDefaultAsync();
        }

        public void CreateSurvey(Survey Survey)
        {
            Create(Survey);
        }

        public void UpdateSurvey(Survey Survey)
        {
            Update(Survey);
        }
        public void DeleteSurvey(Survey Survey)
        {
            Delete(Survey);
        }
    }
}
