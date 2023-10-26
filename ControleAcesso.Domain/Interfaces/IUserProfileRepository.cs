using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<UserProfile> GetByIdAsync(long id);
        Task<IEnumerable<UserProfile>> GetByUserIdAsync(long userId);
        Task<IEnumerable<UserProfile>> GetByProfileIdAsync(long profileId);
    }
}