using Application.Usuarios;
using Application.Usuarios.Dtos;
using Domain.Base.PagedResult;
using Microsoft.AspNetCore.Mvc;

namespace MoneyMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioService;

        public UsuarioController(IUsuarioAppService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<UsuarioDto?> GetById(Guid id)
        {
            return await _usuarioService.GetById(id);
        }

        [HttpPost("GetAll")]
        public PagedResultDto<UsuarioDto> GetAll(SearchUsuarioDto input)
        {
            return _usuarioService.GetAll(input);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUsuarioDto usuarioDto)
        {
            try
            {
                await _usuarioService.Create(usuarioDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao criar o usuário", detalhe = ex.Message });
            }
        }

        [HttpPut("Update")]
        public async Task<UsuarioDto> Update(UpdateUsuarioDto usuarioDto)
        {
            return await _usuarioService.Update(usuarioDto);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao deletar o usuário", detalhe = ex.Message });
            }
        }

        [HttpPut("Active/{id}")]
        public IActionResult Active(Guid id)
        {
            try
            {
                _usuarioService.Active(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao ativar o usuário", detalhe = ex.Message });
            }
        }

        [HttpPut("Deactive/{id}")]
        public IActionResult DeActive(Guid id)
        {
            try
            {
                _usuarioService.DeActive(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao desativar o usuário", detalhe = ex.Message });
            }
        }
    }
}
