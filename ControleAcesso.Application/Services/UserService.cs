using AutoMapper;
using BCryptNet = BCrypt.Net;
using ControleAcesso.Application.DTOs;
using ControleAcesso.Application.Exceptions;
using ControleAcesso.Application.Interfaces;
using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Interfaces;

namespace ControleAcesso.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            IEnumerable<User> user = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(user);
        }
        public async Task<UserDTO> GetByEmail(string email)
        {
            User user = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> GetById(long id)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> GetByUserName(string userName)
        {
            User user = await _unitOfWork.UserRepository.GetByUserNameAsync(userName);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> Login(UserLoginDTO model, string ipClient)
        {
            UserAccess userAccess = new UserAccess(model.UserName, ipClient);
            User userLogin = await _unitOfWork.UserRepository.GetByUserNameAsync(model.UserName);
            bool isSuccess = false;
            if (userLogin != null && userLogin.Active && !userLogin.Blocked)
            {
                isSuccess = BCryptNet.BCrypt.Verify(model.Password, userLogin.Password);
            }
            if (userLogin.Active == false)
            {
                throw new ControleAcessoException("Conta desativada. Entre em contato com o administrador");
            }
            if (userLogin.Blocked)
            {
                throw new ControleAcessoException("Conta bloqueada. Entre em contato com o administrador");
            }
            if (!isSuccess)
            {
                throw new ControleAcessoException("Usuário ou senha incorretos");
            }
            userAccess.SetSuccess(isSuccess);
            _unitOfWork.UserAccessRepository.Add(userAccess);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(userLogin);
        }
        public async Task<UserDTO> Create(UserRegistrationDTO model, string ipClient)
        {
            UserAccess userAccess = new UserAccess(model.UserName, ipClient);
            User userEmail = await _unitOfWork.UserRepository.GetByEmailAsync(model.Email);
            if(userEmail != null)
            {
                throw new ControleAcessoException("O endereço de e-mail já está em uso");
            }
            User userLogin = await _unitOfWork.UserRepository.GetByUserNameAsync(model.UserName);
            if(userLogin != null)
            {
                throw new ControleAcessoException("O nome de usuário já está em uso");
            }
            userAccess.SetSuccess(true);
            User user = _mapper.Map<User>(model);
            user.SetPassword(BCryptNet.BCrypt.HashPassword(model.Password));
            user.SetActive(true);
            user.SetBlocked(false);
            _unitOfWork.UserAccessRepository.Add(userAccess);
            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> Update(UserDTO model, long userId)
        {
            if(userId != model.Id)
            {
                throw new ControleAcessoException("Você não tem autorização para modificar as informações de outro usuário");
            }
            User user = await _unitOfWork.UserRepository.GetByIdAsync(model.Id);
            if(model.UserName != user.UserName)
            {
                throw new ControleAcessoException("Não é possível alterar o nome de usuário");
            }
            if(string.IsNullOrEmpty(model.Password))
            {
                model.Password = user.Password;
            }
            else
            {
                model.Password = BCryptNet.BCrypt.HashPassword(model.Password);
            }
            User userUpdate = _mapper.Map<User>(model);
            _unitOfWork.UserRepository.Update(userUpdate);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }
        public async Task<UserDTO> Delete(long id)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            user.SetActive(false);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }
    }
}