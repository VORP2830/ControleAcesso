using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IProfileRepository : IGenericRepository<Profile>
    {
        Task<IEnumerable<Profile>> GetAllAsync();
        Task<Profile> GetByIdAsync(int id);
    }
}