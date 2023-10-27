using AutoMapper;
using ControleAcesso.Application.DTOs;
using ControleAcesso.Application.Interfaces;
using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;

namespace ControleAcesso.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserProfileService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserProfileDTO>> GetAll()
        {
            IEnumerable<UserProfile> userProfile = await _unitOfWork.UserProfileRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserProfileDTO>>(userProfile);
        }
        public async Task<UserProfileDTO> GetById(long id)
        {
            UserProfile userProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(id);
            return _mapper.Map<UserProfileDTO>(userProfile);
        }
        public async Task<IEnumerable<UserProfileDTO>> GetByProfileId(long profileId)
        {
            IEnumerable<UserProfile> userProfile = await _unitOfWork.UserProfileRepository.GetByProfileIdAsync(profileId);
            return _mapper.Map<IEnumerable<UserProfileDTO>>(userProfile);
        }
        public async Task<IEnumerable<UserProfileDTO>> GetByUserId(long userId)
        {
            IEnumerable<UserProfile> userProfile = await _unitOfWork.UserProfileRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<UserProfileDTO>>(userProfile);
        }
        public async Task<UserProfileDTO> Update(UserProfileDTO model)
        {
            UserProfile userProfile = _mapper.Map<UserProfile>(model);
            _unitOfWork.UserProfileRepository.Update(userProfile);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserProfileDTO>(userProfile);        
        }
        public async Task<UserProfileDTO> Create(UserProfileDTO model)
        {
            UserProfile userProfile = _mapper.Map<UserProfile>(model);
            _unitOfWork.UserProfileRepository.Add(userProfile);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserProfileDTO>(userProfile);
        }
        public async Task<UserProfileDTO> Delete(long id)
        {
            UserProfile userProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(id);
            UserProfileDTO userProfileDTO = _mapper.Map<UserProfileDTO>(userProfile);
            userProfile.SetActive(false);
            _unitOfWork.UserProfileRepository.Update(userProfile);
            await _unitOfWork.SaveChangesAsync();
            return userProfileDTO; 
        }
    }
}