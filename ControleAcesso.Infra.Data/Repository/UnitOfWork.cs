using ControleAcesso.Domain.Interfaces;

namespace ControleAcesso.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        //#TODO Implementar Repositorios do UnitOfWork
        public IUserRepository UserRepository => throw new NotImplementedException();

        public IUserProfileRepository UserProfileRepository => throw new NotImplementedException();

        public IProfileRepository ProfileRepository => throw new NotImplementedException();

        public IFunctionalityProfileRepository FunctionalityProfileRepository => throw new NotImplementedException();

        public IFunctionalityRepository FunctionalityRepository => throw new NotImplementedException();

        public IMethodRepository MethodRepository => throw new NotImplementedException();

        public IMenuOptionRepository MenuOptionRepository => throw new NotImplementedException();

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}