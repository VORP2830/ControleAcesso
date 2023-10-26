using AutoMapper;
using ControleAcesso.Application.DTOs;
using ControleAcesso.Application.Interfaces;
using ControleAcesso.Domain.Interfaces;

namespace ControleAcesso.Application.Services
{
    public class MenuOptionService : IMenuOptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MenuOptionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<MenuOptionDTO>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<MenuOptionDTO>> GetByFunctionalityId(long functionalityId)
        {
            throw new NotImplementedException();
        }
        public Task<MenuOptionDTO> GetById(long id)
        {
            throw new NotImplementedException();
        }
        public Task<MenuOptionDTO> Update(MenuOptionDTO model)
        {
            throw new NotImplementedException();
        }
        public Task<MenuOptionDTO> Create(MenuOptionDTO model)
        {
            throw new NotImplementedException();
        }
        public Task<MenuOptionDTO> Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}