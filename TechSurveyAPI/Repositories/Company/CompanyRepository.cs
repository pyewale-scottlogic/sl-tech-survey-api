using Microsoft.EntityFrameworkCore;
using TechSurveyAPI.Models;

namespace TechSurveyAPI.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(TechnologyStackContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Company>> GetAllCompanysAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync();
        }
        public async Task<Company> GetCompanyByIdAsync(int CompanyId)
        {
            return await FindByCondition(Company => Company.CompanyId.Equals(CompanyId))
                .FirstOrDefaultAsync();
        }
        
        public void CreateCompany(Company Company)
        {
            Create(Company);
        }
        public void UpdateCompany(Company Company)
        {
            Update(Company);
        }
        public void DeleteCompany(Company Company)
        {
            Delete(Company);
        }
    }
}
