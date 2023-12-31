using ControleAcesso.API.Extensions;
using ControleAcesso.Application.DTOs;
using ControleAcesso.Application.Exceptions;
using ControleAcesso.Application.Interfaces;
using ControleAcesso.Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleAcesso.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDTO model)
        {
            try
            {
                var result = await _userService.Create(model, HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(result);
            }
            catch(ControleAcessoException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch(DomainExceptionValidation ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar adicionar usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            try
            {
                var result = await _userService.Login(model, HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(result);
            }
            catch (ControleAcessoException ex)
            {
                var errorResponse = new 
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch(DomainExceptionValidation ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new 
                {
                    Message = "Erro ao tentar fazer login"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _userService.GetAll();
                return Ok(result);
            }
            catch (ControleAcessoException ex)
            {
                var errorResponse = new 
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch(DomainExceptionValidation ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new 
                {
                    Message = "Erro ao tentar pegar todos os usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _userService.GetById(id);
                return Ok(result);
            }
            catch (ControleAcessoException ex)
            {
                var errorResponse = new 
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch(DomainExceptionValidation ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new 
                {
                    Message = "Erro ao tentar pegar usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetPersonalUser")]
        public async Task<IActionResult> GetPersonalUser()
        {
            try
            {
                var result = await _userService.GetById(User.GetUserId());
                return Ok(result);
            }
            catch (ControleAcessoException ex)
            {
                var errorResponse = new 
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch(DomainExceptionValidation ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new 
                {
                    Message = "Erro ao tentar pegar usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut("UpdatePersonalUser")]
        public async Task<IActionResult> UpdatePerosnalUser(UserUpdateDTO model)
        {
            try
            {
                var result = await _userService.Update(model, User.GetUserId());
                return Ok(result);
            }
            catch(ControleAcessoException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch(DomainExceptionValidation ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar alterar usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _userService.Delete(id);
                return Ok(result);
            }
            catch(ControleAcessoException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch(DomainExceptionValidation ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar deletar usuário"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}