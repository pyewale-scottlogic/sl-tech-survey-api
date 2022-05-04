using TechSurveyAPI.Models;

namespace TechSurveyAPI.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TechnologyStackContext _repoContext;

        private ICompanyRepository _company;
        private IEmployeeRepository _employee;

        public RepositoryWrapper(TechnologyStackContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
        public ICompanyRepository Company
        {
            get
            {
                if (_company == null)
                {
                    _company = new CompanyRepository(_repoContext);
                }
                return _company;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }
                return _employee;
            }
        }

        public IPlatformRepository Platform => throw new NotImplementedException();

        public IProjectRepository Project => throw new NotImplementedException();

        public IProjectOwnerRepository ProjectOwner => throw new NotImplementedException();

        public ISurveyRepository Survey => throw new NotImplementedException();

        public ITechnologyRepository Technology => throw new NotImplementedException();
    }
}
