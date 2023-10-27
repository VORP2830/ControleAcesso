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
    public class MethodController : ControllerBase
    {
        private readonly IMethodService _methodService;
        public MethodController(IMethodService methodService)
        {
            _methodService = methodService;
        } 
        [HttpGet("GetAllMethod")]
        public async Task<IActionResult> GetAllMethod()
        {
            try
            {
                var result = await _methodService.GetAll();
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
                    Message = "Erro ao tentar pegar todos os metodos",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _methodService.GetById(id);
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
                    Message = "Erro ao tentar pegar metodo",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetByFunctionalityId/{id}")]
        public async Task<IActionResult> GetByFunctionalityId(long id)
        {
            try
            {
                var result = await _methodService.GetByFunctionalityId(id);
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
                    Message = "Erro ao tentar pegar metodo por funcionalidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost("CreateMethod")]
        public async Task<IActionResult> Create(MethodDTO model)
        {
            try
            {
                var result = await _methodService.Create(model);
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
                    Message = "Erro ao tentar criar metodo",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut("UpdateMethod")]
        public async Task<IActionResult> Update(MethodDTO model)
        {
            try
            {
                var result = await _methodService.Update(model);
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
                    Message = "Erro ao tentar alterar metodo",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpDelete("DeleteMethod/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _methodService.Delete(id);
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
                    Message = "Erro ao tentar deletar metodo",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [AllowAnonymous]
        [HttpPost("Teste")]
        public async Task<IActionResult> teste(int userId, string className, string action)
        {
            var result = await _methodService.GetPermissionMethodByUserId(userId, className, action);
            return Ok(result);
        }
    }
}