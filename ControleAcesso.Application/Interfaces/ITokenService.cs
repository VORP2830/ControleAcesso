using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAcesso.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(long userId, string userName);
    }
}