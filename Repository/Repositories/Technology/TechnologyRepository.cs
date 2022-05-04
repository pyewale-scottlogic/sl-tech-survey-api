using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repositories
{
    public class TechnologyRepository : RepositoryBase<Technology>, ITechnologyRepository
    {

        public TechnologyRepository(TechnologyStackContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateTechnology(Technology technology)
        {
            Create(technology);
        }

        public void DeleteTechnology(Technology technology)
        {
            Delete(technology);
        }

        public void UpdateTechnology(Technology technology)
        {
            Update(technology);

        }
        public async Task<IEnumerable<Technology>> GetAllTechnologiesAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync();
        }

        public async Task<Technology> GetTechnologyByIdAsync(int technologyId)
        {
            return await FindByCondition(technology => technology.TechnologyId.Equals(technologyId))
                 .FirstOrDefaultAsync();
        }

        
    }
}
