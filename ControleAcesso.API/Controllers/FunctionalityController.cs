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
    public class FunctionalityController : ControllerBase
    {
        private readonly IFunctionalityService _functionalityService;
        public FunctionalityController(IFunctionalityService functionalityService)
        {
            _functionalityService = functionalityService;
        } 
        [HttpGet("GetAllFunctionality")]
        public async Task<IActionResult> GetAllFunctionality()
        {
            try
            {
                var result = await _functionalityService.GetAll();
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
                    Message = "Erro ao tentar pegar todos as funcionalidades",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _functionalityService.GetById(id);
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
                    Message = "Erro ao tentar pegar funcionalidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost("CreateFunctionality")]
        public async Task<IActionResult> Create(FunctionalityDTO model)
        {
            try
            {
                var result = await _functionalityService.Create(model);
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
                    Message = "Erro ao tentar criar funcionalidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut("UpdateFunctionality")]
        public async Task<IActionResult> Update(FunctionalityDTO model)
        {
            try
            {
                var result = await _functionalityService.Update(model);
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
                    Message = "Erro ao tentar alterar funcionalidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpDelete("DeleteFunctionality/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _functionalityService.Delete(id);
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
                    Message = "Erro ao tentar deletar funcionalidade",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}