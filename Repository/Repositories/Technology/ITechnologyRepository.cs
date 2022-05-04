using Repository.Models;

namespace Repository.Repositories
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<Technology>> GetAllTechnologiesAsync();
        Task<Technology> GetTechnologyByIdAsync(int TechnologyId);
        void CreateTechnology(Technology Technology);
        void UpdateTechnology(Technology Technology);
        void DeleteTechnology(Technology Technology);
    }
}
    
