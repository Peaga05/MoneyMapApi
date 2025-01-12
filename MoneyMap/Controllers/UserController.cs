using Application.Usuarios;
using Application.Usuarios.Dtos;
using Domain.Base.PagedResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoneyMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userService;

        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("GetById/{id}")]
        public async Task<UserDto?> GetById(Guid id)
        {
            return await _userService.GetById(id);
        }

        [Authorize]
        [HttpPost("GetAll")]
        public PagedResultDto<UserDto> GetAll(SearchUserDto input)
        {
            return _userService.GetAll(input);
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserDto usuarioDto)
        {
            try
            {
                await _userService.Create(usuarioDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao criar o usuário", detalhe = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<UserDto> Update(UpdateUserDto usuarioDto)
        {
            return await _userService.Update(usuarioDto);
        }

        [Authorize]
        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao deletar o usuário", detalhe = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("Active/{id}")]
        public IActionResult Active(Guid id)
        {
            try
            {
                _userService.Active(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao ativar o usuário", detalhe = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("Deactive/{id}")]
        public IActionResult DeActive(Guid id)
        {
            try
            {
                _userService.DeActive(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao desativar o usuário", detalhe = ex.Message });
            }
        }
    }
}
