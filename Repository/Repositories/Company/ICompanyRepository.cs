using Repository.Models;

namespace Repository.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<IEnumerable<Company>> GetAllCompanysAsync();
        Task<Company> GetCompanyByIdAsync(int CompanyId);
        
        void CreateCompany(Company Company);
        void UpdateCompany(Company Company);
        void DeleteCompany(Company Company);
    }
}
