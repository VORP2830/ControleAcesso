using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IProfileRepository : IGenericRepository<Profile>
    {
        Task<Profile> GetAllAsync();
        Task<Profile> GetByIdAsync(int id);
    }
}