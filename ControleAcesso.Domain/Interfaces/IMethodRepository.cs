using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IMethodRepository : IGenericRepository<Methods>
    {
        Task<IEnumerable<Methods>> GetAllAsync();
        Task<Methods> GetByIdAsync(long id);
        Task<IEnumerable<Methods>> GetByFunctionalityIdAsync(long functionalityId);
    }
}