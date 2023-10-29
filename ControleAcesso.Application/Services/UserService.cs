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
        private readonly ITokenService _tokenService;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
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
        public async Task<Object> Login(UserLoginDTO model, string ipClient)
        {
            UserAccess userAccess = new UserAccess(model.UserName, ipClient);
            User userLogin = await _unitOfWork.UserRepository.GetByUserNameAsync(model.UserName);
            bool isSuccess = false;
            if (userLogin != null)
            {
                isSuccess = BCryptNet.BCrypt.Verify(model.Password, userLogin.Password);
                if (userLogin.Active == false)
                {
                    await SetUserAcess(userAccess, false);
                    throw new ControleAcessoException("Conta desativada. Entre em contato com o administrador");
                }
                if (userLogin.Blocked)
                {
                    await SetUserAcess(userAccess, false);
                    throw new ControleAcessoException("Conta bloqueada. Entre em contato com o administrador");
                }
                if(!isSuccess)
                {
                    await BlockUser(model.UserName);  
                }
            }
            if (!isSuccess)
            {
                await SetUserAcess(userAccess, isSuccess);
                throw new ControleAcessoException("Usuário ou senha incorretos");
            }
            if(isSuccess)
            {
                await SetUserAcess(userAccess, isSuccess);
                var token = await _tokenService.GenerateToken(userLogin.Id, userLogin.UserName);
                return new {
                        name = userLogin.Name,
                        token = token
                };
            }
            throw new ControleAcessoException("Usuário ou senha incorretos");
        }
        public async Task<Object> Create(UserRegistrationDTO model, string ipClient)
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
            var token = await _tokenService.GenerateToken(user.Id, user.UserName);
            return new {
                    name = user.Name,
                    token = token
            };
        }
        public async Task<UserDTO> Update(UserUpdateDTO model, long userId)
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
            return _mapper.Map<UserDTO>(model);
        }
        public async Task<UserDTO> Delete(long id)
        {
            User user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            user.SetActive(false);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }
        private async Task BlockUser(string userName)
        {
            IEnumerable<UserAccess> userAccess = await _unitOfWork.UserAccessRepository.GetTop5ByUserName(userName);
            if(userAccess.Count() == 5)
            {
                bool hasSuccess = userAccess.Any(access => access.Success);
                if (!hasSuccess)
                {
                    User user = await _unitOfWork.UserRepository.GetByUserNameAsync(userName);
                    user.SetBlocked(true);
                    _unitOfWork.UserRepository.Update(user);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
        }
        private async Task SetUserAcess(UserAccess userAccess, bool isSuccess)
        {
            userAccess.SetSuccess(isSuccess);
            _unitOfWork.UserAccessRepository.Add(userAccess);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}