using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<UserProfile> GetByIdAsync(int id);
        Task<IEnumerable<UserProfile>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserProfile>> GetByProfileIdAsync(int profileId);
    }
}