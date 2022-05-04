using Repository.Models;

namespace Repository.Repositories
{
    public interface ICompanyRepositoryOld
    {
        public Task<Company> Get(int id);
        public Task<Company> Add(Company company);
    }
}
