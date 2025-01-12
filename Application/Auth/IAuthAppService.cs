using Application.Auth.Dto;

namespace Application.Auth
{
    public interface IAuthAppService
    {
        Task<string> Login(LoginDto loginDto);
    }
}
