using AutoMapper;
using ControleAcesso.Application.DTOs;
using ControleAcesso.Application.Interfaces;
using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;

namespace ControleAcesso.Application.Services
{
    public class FunctionalityService : IFunctionalityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FunctionalityService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<FunctionalityDTO>> GetAll()
        {
            IEnumerable<Functionality> functionality = await _unitOfWork.FunctionalityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FunctionalityDTO>>(functionality);
        }
        public async Task<FunctionalityDTO> GetById(long id)
        {
            Functionality functionality = await _unitOfWork.FunctionalityRepository.GetByIdAsync(id);
            return _mapper.Map<FunctionalityDTO>(functionality);
        }
        public async Task<FunctionalityDTO> Create(FunctionalityDTO model)
        {
            Functionality functionality = _mapper.Map<Functionality>(model);
            _unitOfWork.FunctionalityRepository.Add(functionality);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<FunctionalityDTO>(functionality);
        }
        public async Task<FunctionalityDTO> Update(FunctionalityDTO model)
        {
            Functionality functionality = _mapper.Map<Functionality>(model);
            _unitOfWork.FunctionalityRepository.Update(functionality);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<FunctionalityDTO>(functionality);
        }
        public async Task<FunctionalityDTO> Delete(long id)
        {
            Functionality functionality = await _unitOfWork.FunctionalityRepository.GetByIdAsync(id);
            functionality.SetActive(false);
            _unitOfWork.FunctionalityRepository.Update(functionality);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<FunctionalityDTO>(functionality);
        }
    }
}