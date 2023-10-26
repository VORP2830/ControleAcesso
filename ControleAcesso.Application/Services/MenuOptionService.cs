using AutoMapper;
using ControleAcesso.Application.DTOs;
using ControleAcesso.Application.Interfaces;
using ControleAcesso.Domain.Entities;
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
        public async Task<IEnumerable<MenuOptionDTO>> GetAll()
        {
            IEnumerable<MenuOption> menuOptions = await _unitOfWork.MenuOptionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuOptionDTO>>(menuOptions);
        }
        public async Task<IEnumerable<MenuOptionDTO>> GetByFunctionalityId(long functionalityId)
        {
            IEnumerable<MenuOption> menuOptions = await _unitOfWork.MenuOptionRepository.GetByFunctionalityIdAsync(functionalityId);
            return _mapper.Map<IEnumerable<MenuOptionDTO>>(menuOptions);
        }
        public async Task<MenuOptionDTO> GetById(long id)
        {
            MenuOption menuOption = await _unitOfWork.MenuOptionRepository.GetByIdAsync(id);
            return _mapper.Map<MenuOptionDTO>(menuOption);
        }
        public async Task<MenuOptionDTO> Update(MenuOptionDTO model)
        {
            MenuOption menuOption = _mapper.Map<MenuOption>(model);
            _unitOfWork.MenuOptionRepository.Update(menuOption);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }
        public async Task<MenuOptionDTO> Create(MenuOptionDTO model)
        {
            MenuOption menuOption = _mapper.Map<MenuOption>(model);
            _unitOfWork.MenuOptionRepository.Add(menuOption);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }
        public async Task<MenuOptionDTO> Delete(long id)
        {
            MenuOption menuOption = await _unitOfWork.MenuOptionRepository.GetByIdAsync(id);
            menuOption.SetActive(false);
            _unitOfWork.MenuOptionRepository.Update(menuOption);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MenuOptionDTO>(menuOption);
        }
    }
}