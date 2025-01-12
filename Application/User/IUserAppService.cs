using Application.Usuarios.Dtos;
using Domain.Base.PagedResult;

namespace Application.Usuarios
{
    public interface IUserAppService
    {
        Task Create(CreateUserDto userDto);
        Task<UserDto> Update(UpdateUserDto userDto);
        void Delete(Guid id);
        void DeActive(Guid id);
        void Active(Guid id);
        Task<UserDto> GetById(Guid id);
        PagedResultDto<UserDto> GetAll(SearchUserDto input);
    }
}