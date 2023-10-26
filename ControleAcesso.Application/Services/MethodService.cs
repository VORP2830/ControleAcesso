using AutoMapper;
using ControleAcesso.Application.DTOs;
using ControleAcesso.Application.Interfaces;
using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;

namespace ControleAcesso.Application.Services
{
    public class MethodService : IMethodService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MethodService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MethodDTO>> GetAll()
        {
            IEnumerable<Methods> methods = await _unitOfWork.MethodRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MethodDTO>>(methods);
        }
        public async Task<IEnumerable<MethodDTO>> GetByFunctionalityId(long functionalityId)
        {
            IEnumerable<Methods> methods = await _unitOfWork.MethodRepository.GetByFunctionalityIdAsync(functionalityId);
            return _mapper.Map<IEnumerable<MethodDTO>>(methods);
        }
        public async Task<MethodDTO> GetById(long id)
        {
            Methods methods = await _unitOfWork.MethodRepository.GetByIdAsync(id);
            return _mapper.Map<MethodDTO>(methods);
        }
        public async Task<MethodDTO> Create(MethodDTO model)
        {
            Methods method = _mapper.Map<Methods>(model);
            _unitOfWork.MethodRepository.Add(method);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MethodDTO>(method);
        }
        public async Task<MethodDTO> Update(MethodDTO model)
        {
            Methods method = _mapper.Map<Methods>(model);
            _unitOfWork.MethodRepository.Update(method);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MethodDTO>(method);
        }
        public async Task<MethodDTO> Delete(long id)
        {
            Methods method = await _unitOfWork.MethodRepository.GetByIdAsync(id);
            method.SetActive(false);
            _unitOfWork.MethodRepository.Update(method);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MethodDTO>(method);
        }
    }
}