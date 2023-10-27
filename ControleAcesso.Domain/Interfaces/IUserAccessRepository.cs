using ControleAcesso.Domain.Entities;

namespace ControleAcesso.Domain.Interfaces
{
    public interface IUserAccessRepository : IGenericRepository<UserAccess>
    { 
        Task<IEnumerable<UserAccess>> GetTop5ByUserName(string userName);
    }
}