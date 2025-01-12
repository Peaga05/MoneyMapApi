using Application.Usuarios.Dtos;
using AutoMapper;
using Domain.Base.PagedResult;
using Domain.Entities;
using Infrastructure.Constants;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Application.Usuarios
{
    public class UserAppService : IUserAppService
    {
        private readonly IRepository<User> _repository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public UserAppService(
            IRepository<User> repository,
            IPasswordService passwordService,
            IMapper mapper)
        {
            _repository = repository;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        public async void Active(Guid id)
        {
            var user = await _repository.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (user == null) throw new Exception(UserConstants.UserNotExist);
            _repository.Active(user);
        }

        public async Task Create(CreateUserDto userDto)
        {
          
                var existEmail = await ExistEmailAsync(userDto.Email);
                if (existEmail) throw new Exception(UserConstants.DuplicateEmail);

                var user = _mapper.Map<User>(userDto);
                user.Password = _passwordService.EncryptPassword(user.Password);
                await _repository.InsertAsync(user);    
        }

        public async void DeActive(Guid id)
        {
            var user = await _repository.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (user == null) throw new Exception(UserConstants.UserNotExist);
            _repository.DeActive(user);
        }

        public async void Delete(Guid id)
        {
            var user = await _repository.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (user == null) throw new Exception(UserConstants.UserNotExist);
            _repository.Delete(user);
        }

        public PagedResultDto<UserDto> GetAll(SearchUserDto input)
        {
            var query = _repository.GetAll().AsNoTracking();
            if (!input.Email.IsNullOrEmpty())
                query = query.Where(x => x.Email.Contains(input.Email));
            
            if (!input.Name.IsNullOrEmpty())
                query = query.Where(x => x.Name.Contains(input.Name));
            

            var amount = query.Count();
            var usuarios = query.Skip(input.Skip).Take(input.Take).ToList();

            return new PagedResultDto<UserDto>
            {
                Amount = amount,
                Result = _mapper.Map<List<UserDto>>(usuarios)
            };
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await _repository.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(user == null) throw new Exception(UserConstants.UserNotExist);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Update(UpdateUserDto userDto)
        {
            var existEmail = await ExistEmailAsync(userDto.Email);
            if (existEmail) throw new Exception(UserConstants.DuplicateEmail);

            var user = _mapper.Map<User>(userDto);
            await _repository.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        private async Task<bool> ExistEmailAsync(string email)
        {
            return await _repository.FirstOrDefaultAsync(x => x.Email.Equals(email)) != null;
        }
    }
}
