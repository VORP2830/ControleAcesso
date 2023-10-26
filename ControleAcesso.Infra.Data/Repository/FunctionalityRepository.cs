using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data.Repository
{
    public class FunctionalityRepository : GenericRepository<Functionality>, IFunctionalityRepository
    {
        private readonly ApplicationDbContext _context;
        public FunctionalityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Functionality>> GetAllAsync()
        {
            return await _context.Functionalities
                                    .ToListAsync();
        }
        public async Task<Functionality> GetByIdAsync(long id)
        {
            return await _context.Functionalities
                                    .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}