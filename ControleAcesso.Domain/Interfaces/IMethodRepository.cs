using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IMethodRepository : IGenericRepository<Methods>
    {
        Task<IEnumerable<Methods>> GetAllAsync();
        Task<Methods> GetByIdAsync(int id);
        Task<IEnumerable<Methods>> GetByFunctionalityIdAsync(int functionalityId);
    }
}