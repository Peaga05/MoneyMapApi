using Application.Auth;
using Application.Auth.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MoneyMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService _authService;

        public AuthController(IAuthAppService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto request)
        {
            var token = await _authService.Login(request);
            if(token.IsNullOrEmpty()) return Unauthorized("Usuário ou senha inválidos.");

            return Ok(new { Token = token });
        }
    }
}
