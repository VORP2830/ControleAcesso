using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAcesso.Infra.Data.Repository
{
    
    public class UserAccessRepository : GenericRepository<UserAccess>, IUserAccessRepository
    {
        private readonly ApplicationDbContext _context;
        public UserAccessRepository(ApplicationDbContext context) : base(context)
        {
           _context = context;
        }
    }
}
