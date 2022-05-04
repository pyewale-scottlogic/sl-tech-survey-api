using TechSurveyAPI.Models;

namespace TechSurveyAPI.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<IEnumerable<Company>> GetAllCompanysAsync();
        Task<Company> GetCompanyByIdAsync(int CompanyId);
        //Task<Company> GetCompanyWithDetailsAsync(int CompanyId);
        void CreateCompany(Company Company);
        void UpdateCompany(Company Company);
        void DeleteCompany(Company Company);
    }
}
