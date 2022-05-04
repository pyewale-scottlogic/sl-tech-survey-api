using TechSurveyAPI.DTOs;
using TechSurveyAPI.Models;

namespace TechSurveyAPI.Repositories
{
    public class CompanyRepositoryOld : ICompanyRepositoryOld
    {
        TechnologyStackContext _dbContext;

        public CompanyRepositoryOld(TechnologyStackContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company> Add(Company company)
        {
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();
            return company;
        }

        public async Task<Company> Get(int id)
        {
            return await _dbContext.Companies.FindAsync(id);
        }
    }
}
