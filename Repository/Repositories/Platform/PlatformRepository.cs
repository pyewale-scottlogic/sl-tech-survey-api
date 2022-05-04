using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Repositories
{
    public class PlatformRepository : RepositoryBase<Platform>, IPlatformRepository
    {

        public PlatformRepository(TechnologyStackContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync();
        }

        public async Task<Platform> GetPlatformByIdAsync(int PlatformId)
        {
            return await FindByCondition(Platform => Platform.PlatformId.Equals(PlatformId))
                .FirstOrDefaultAsync();
        }

        public void CreatePlatform(Platform Platform)
        {
            Create(Platform);
        }

        public void UpdatePlatform(Platform Platform)
        {
            Update(Platform);
        }
        public void DeletePlatform(Platform Platform)
        {
            Delete(Platform);
        }
    }
}
