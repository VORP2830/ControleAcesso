using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        Task<UserProfile> GetAllAsync();
        Task<UserProfile> GetByIdAsync(int id);
        Task<UserProfile> GetByUserIdAsync(int userId);
        Task<UserProfile> GetByProfileIdAsync(int profileId);
    }
}