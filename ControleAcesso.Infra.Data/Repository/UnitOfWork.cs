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
        public IUserRepository UserRepository => new UserRepository(_context);

        public IUserProfileRepository UserProfileRepository => new UserProfileRepository(_context);

        public IProfileRepository ProfileRepository => new ProfileRepository(_context);

        public IFunctionalityProfileRepository FunctionalityProfileRepository => new FunctionalityProfileRepository(_context);

        public IFunctionalityRepository FunctionalityRepository => new FunctionalityRepository(_context);

        public IMethodRepository MethodRepository => new MethodRepository(_context);

        public IMenuOptionRepository MenuOptionRepository => new MenuOptionRepository(_context);

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}