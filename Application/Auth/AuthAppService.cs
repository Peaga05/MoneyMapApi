using Application.Auth.Dto;
using Domain.Entities;
using Infrastructure.Auth;
using Infrastructure.Constants;
using Infrastructure.Repository;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;

        public AuthAppService(
            IRepository<User> userRepository,
            ITokenService tokenService,
             IPasswordService passwordService
        )
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Email.Equals(loginDto.Email));
            if (user == null || !_passwordService.ValidedPassword(loginDto.Password, user.Password)) 
                throw new Exception(UserConstants.LoginError);

            return _tokenService.GenerateToken(user.Id.ToString(), user.Name);  
        }
    }
}
