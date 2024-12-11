using Application.Usuarios.Dtos;
using Domain.Base.PagedResult;

namespace Application.Usuarios
{
    public interface IUsuarioAppService
    {
        Task Create(CreateUsuarioDto usuarioDto);
        Task<UsuarioDto> Update(UpdateUsuarioDto usuarioDto);
        void Delete(Guid id);
        void DeActive(Guid id);
        void Active(Guid id);
        Task<UsuarioDto> GetById(Guid id);
        PagedResultDto<UsuarioDto> GetAll(SearchUsuarioDto input);
    }
}