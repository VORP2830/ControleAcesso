namespace ControleAcesso.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync(); 
    }
}