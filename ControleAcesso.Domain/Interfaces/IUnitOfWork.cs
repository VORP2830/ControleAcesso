namespace ControleAcesso.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IProfileRepository ProfileRepository { get; }
        IFunctionalityProfileRepository FunctionalityProfileRepository { get; }
        IFunctionalityRepository FunctionalityRepository { get; }
        IMethodRepository MethodRepository { get; }
        IMenuOptionRepository MenuOptionRepository { get; }
        IUserAccessRepository UserAccessRepository { get; }
        Task<bool> SaveChangesAsync(); 
    }
}