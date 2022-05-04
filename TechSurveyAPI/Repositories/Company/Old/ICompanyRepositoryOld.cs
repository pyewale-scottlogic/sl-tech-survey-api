using TechSurveyAPI.Models;

namespace TechSurveyAPI.Repositories
{
    public interface ICompanyRepositoryOld
    {
        public Task<Company> Get(int id);
        public Task<Company> Add(Company company);
    }
}
