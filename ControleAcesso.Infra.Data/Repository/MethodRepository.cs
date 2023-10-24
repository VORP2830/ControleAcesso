using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data.Repository
{
    public class MethodRepository : GenericRepository<Methods>, IMethodRepository
    {
        private readonly ApplicationDbContext _context;
        public MethodRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Methods>> GetAllAsync()
        {
            return await _context.Methods
                                    .ToListAsync();
        }
        public async Task<IEnumerable<Methods>> GetByFunctionalityIdAsync(int functionalityId)
        {
            return await _context.Methods
                                    .Where(m => m.FunctionalityId == functionalityId)
                                    .ToListAsync();
        }
        public async Task<Methods> GetByIdAsync(int id)
        {
            return await _context.Methods
                                    .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}