using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IFunctionalityRepository : IGenericRepository<Functionality>
    {
        Task<IEnumerable<Functionality>> GetAllAsync();
        Task<Functionality> GetByIdAsync(int id);
    }
}