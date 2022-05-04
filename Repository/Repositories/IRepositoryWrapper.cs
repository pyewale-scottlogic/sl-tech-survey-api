namespace Repository.Repositories
{
    public interface IRepositoryWrapper
    {
        ICompanyRepository Company { get; }

        IEmployeeRepository Employee { get; }

        IPlatformRepository Platform { get; }

        IProjectRepository Project { get; }

        IProjectOwnerRepository ProjectOwner { get; }

        ISurveyRepository Survey { get; }

        ITechnologyRepository Technology { get; }
        Task SaveAsync();
    }
}
