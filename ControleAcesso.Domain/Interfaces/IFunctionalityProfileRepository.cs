using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IFunctionalityProfileRepository : IGenericRepository<FunctionalityProfile>
    {
        Task<IEnumerable<FunctionalityProfile>> GetAllAsync();
        Task<FunctionalityProfile> GetByIdAsync(long id);
        Task<IEnumerable<FunctionalityProfile>> GetByProfileIdAsync(long profileId);
        Task<IEnumerable<FunctionalityProfile>> GetByFunctionalityIdAsync(long functionalityId);
    }
}