using AutoMapper;
using ControleAcesso.Application.DTOs;
using ControleAcesso.Application.Interfaces;
using ControleAcesso.Domain.Interfaces;

namespace ControleAcesso.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProfileService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProfileDTO>> GetAll()
        {
            IEnumerable<Domain.Entities.Profile> profile = await _unitOfWork.ProfileRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProfileDTO>>(profile);
        }

        public async Task<ProfileDTO> GetById(long id)
        {
            Domain.Entities.Profile profile = await _unitOfWork.ProfileRepository.GetByIdAsync(id);
            return _mapper.Map<ProfileDTO>(profile);
        }

        public async Task<ProfileDTO> Create(ProfileDTO model)
        {
            var profile = _mapper.Map<Domain.Entities.Profile>(model);
            _unitOfWork.ProfileRepository.Add(profile);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }

        public async Task<ProfileDTO> Delete(long id)
        {
            var profile = await _unitOfWork.ProfileRepository.GetByIdAsync(id);
            profile.SetActive(false);
            _unitOfWork.ProfileRepository.Update(profile);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProfileDTO>(profile);
        }

        public async Task<ProfileDTO> Update(ProfileDTO model)
        {
            var profile = _mapper.Map<Domain.Entities.Profile>(model);
            _unitOfWork.ProfileRepository.Update(profile);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }
    }
}