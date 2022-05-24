using Repository.Models;

namespace Repository.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TechnologyStackContext _repoContext;

        private ICompanyRepository _company;
        private IProjectRepository      _project;
        private IEmployeeRepository     _employee;
        private IPlatformRepository     _platform;
        private ITechnologyRepository   _technology;
        //private ISurveyRepository       _survey;
        private IProjectOwnerRepository _projectOwner;
        private IProjectSurveyRepository _projectSurvey;
        

        public RepositoryWrapper(TechnologyStackContext repositoryContext)
        {
            _repoContext = repositoryContext;
            _project = new ProjectRepository(_repoContext);
            _employee = new EmployeeRepository(_repoContext);
            _platform = new PlatformRepository(_repoContext);
            _technology = new TechnologyRepository(_repoContext);
            //_survey = new SurveyRepository(_repoContext);
            _projectOwner = new ProjectOwnerRepository(_repoContext);
            _projectSurvey = new ProjectSurveyRepository(_repoContext);
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

        public IPlatformRepository Platform { get { return _platform; } }

        public IProjectRepository Project { get { return _project; } }

        public IProjectOwnerRepository ProjectOwner { get { return _projectOwner; } }

        //public ISurveyRepository Survey { get { return _survey; } }

        public ITechnologyRepository Technology { get { return _technology; } }

        public IProjectSurveyRepository ProjectSurvey { get { return _projectSurvey; } }
    }
}
