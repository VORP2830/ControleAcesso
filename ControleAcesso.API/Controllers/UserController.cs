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
                var user = await _userService.Create(model, HttpContext.Connection.RemoteIpAddress.ToString());
                return Ok(user);
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
            catch (Exception)
            {
                var errorResponse = new 
                {
                    Message = "Erro ao tentar fazer login",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
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
        [HttpGet("{id}")]
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
        [HttpPut]
        public async Task<IActionResult> Update(UserDTO model)
        {
            try
            {
                var user = await _userService.Update(model, User.GetUserId());
                return Ok(user);
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
    }
}