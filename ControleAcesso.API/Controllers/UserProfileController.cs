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
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }
        [HttpGet("GetAllUserProfiles")]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            try
            {
                var result = await _userProfileService.GetAll();
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
                    Message = "Erro ao tentar pegar todos os perfies dos usuários",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _userProfileService.GetById(id);
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
                    Message = "Erro ao tentar pegar perfil do usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetByProfileId/{id}")]
        public async Task<IActionResult> GetByProfileId(long id)
        {
            try
            {
                var result = await _userProfileService.GetByProfileId(id);
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
                    Message = "Erro ao tentar pegar perfil do usuário por perfil",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(long id)
        {
            try
            {
                var result = await _userProfileService.GetByUserId(id);
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
                    Message = "Erro ao tentar pegar perfil do usuário por perfil",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost("CreateProfile")]
        public async Task<IActionResult> Create(UserProfileDTO model)
        {
            try
            {
                var result = await _userProfileService.Create(model);
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
                    Message = "Erro ao tentar criar perfil do usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> Update(UserProfileDTO model)
        {
            try
            {
                var result = await _userProfileService.Update(model);
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
                    Message = "Erro ao tentar alterar perfil do usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpDelete("DeleteProfile/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _userProfileService.Delete(id);
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
                    Message = "Erro ao tentar deletar perfil do usuário",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}