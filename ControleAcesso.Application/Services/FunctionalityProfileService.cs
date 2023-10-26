using AutoMapper;
using ControleAcesso.Application.DTOs;
using ControleAcesso.Application.Interfaces;
using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;

namespace ControleAcesso.Application.Services
{
    public class FunctionalityProfileService : IFunctionalityProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FunctionalityProfileService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<FunctionalityProfileDTO>> GetAll()
        {
            IEnumerable<FunctionalityProfile> functionalityProfile = await _unitOfWork.FunctionalityProfileRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FunctionalityProfileDTO>>(functionalityProfile);
        }
        public async Task<IEnumerable<FunctionalityProfileDTO>> GetByFunctionalityId(long functionalityId)
        {
            IEnumerable<FunctionalityProfile> functionalityProfile = await _unitOfWork.FunctionalityProfileRepository.GetByFunctionalityIdAsync(functionalityId);
            return _mapper.Map<IEnumerable<FunctionalityProfileDTO>>(functionalityProfile);
        }
        public async Task<FunctionalityProfileDTO> GetById(long id)
        {
            FunctionalityProfile functionalityProfile = await _unitOfWork.FunctionalityProfileRepository.GetByIdAsync(id);
            return _mapper.Map<FunctionalityProfileDTO>(functionalityProfile);
        }
        public async Task<IEnumerable<FunctionalityProfileDTO>> GetByProfileId(long profileId)
        {
            IEnumerable<FunctionalityProfile> functionalityProfile = await _unitOfWork.FunctionalityProfileRepository.GetByProfileIdAsync(profileId);
            return _mapper.Map<IEnumerable<FunctionalityProfileDTO>>(functionalityProfile);
        }
        public async Task<FunctionalityProfileDTO> Create(FunctionalityProfileDTO model)
        {
            FunctionalityProfile functionalityProfile = _mapper.Map<FunctionalityProfile>(model);
            _unitOfWork.FunctionalityProfileRepository.Add(functionalityProfile);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }
        public async Task<FunctionalityProfileDTO> Update(FunctionalityProfileDTO model)
        {
            FunctionalityProfile functionalityProfile = _mapper.Map<FunctionalityProfile>(model);
            _unitOfWork.FunctionalityProfileRepository.Update(functionalityProfile);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }
        public async Task<FunctionalityProfileDTO> Delete(long id)
        {
            FunctionalityProfile functionalityProfile = await _unitOfWork.FunctionalityProfileRepository.GetByIdAsync(id);
            functionalityProfile.SetActive(false);
            _unitOfWork.FunctionalityProfileRepository.Update(functionalityProfile);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<FunctionalityProfileDTO>(functionalityProfile);
        }
    }
}