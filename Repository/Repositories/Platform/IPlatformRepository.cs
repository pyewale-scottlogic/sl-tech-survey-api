using Repository.Models;

namespace Repository.Repositories
{
    public interface IPlatformRepository
    {
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task<Platform> GetPlatformByIdAsync(int PlatformId);
        void CreatePlatform(Platform Platform);
        void UpdatePlatform(Platform Platform);
        void DeletePlatform(Platform Platform);
    }
}
