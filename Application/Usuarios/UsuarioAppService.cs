using Application.Usuarios.Dtos;
using AutoMapper;
using Domain.Base.PagedResult;
using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Application.Usuarios
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper _mapper;

        public UsuarioAppService(IRepository<Usuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async void Active(Guid id)
        {
            var usuario = await _repository.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (usuario == null) throw new Exception("Usuário não encontrado");
            _repository.Active(usuario);
        }

        public async Task Create(CreateUsuarioDto usuarioDto)
        {
            var existEmail = await ExistEmailAsync(usuarioDto.Email);
            if (existEmail) throw new Exception("E-mail vinculado a outro usuário!");

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _repository.InsertAsync(usuario);
        }

        public async void DeActive(Guid id)
        {
            var usuario = await _repository.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (usuario == null) throw new Exception("Usuário não encontrado");
            _repository.DeActive(usuario);
        }

        public async void Delete(Guid id)
        {
            var usuario = await _repository.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (usuario == null) throw new Exception("Usuário não encontrado");
            _repository.Delete(usuario);
        }

        public PagedResultDto<UsuarioDto> GetAll(SearchUsuarioDto input)
        {
            var query = _repository.GetAll().AsNoTracking();
            if (!input.Email.IsNullOrEmpty())
            {
                query = query.Where(x => x.Email.Contains(input.Email));
            }
            if (!input.Nome.IsNullOrEmpty())
            {
                query = query.Where(x => x.Nome.Contains(input.Nome));
            }

            var quantidade = query.Count();
            var usuarios = query.Skip(input.Skip).Take(input.Take).ToList();

            return new PagedResultDto<UsuarioDto>
            {
                Quantidade = quantidade,
                Result = _mapper.Map<List<UsuarioDto>>(usuarios)
            };
        }

        public async Task<UsuarioDto> GetById(Guid id)
        {
            var usuario = await _repository.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(usuario == null) throw new Exception("Usuário não encontrado");

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> Update(UpdateUsuarioDto usuarioDto)
        {
            var existEmail = await ExistEmailAsync(usuarioDto.Email);
            if (existEmail) throw new Exception("E-mail vinculado a outro usuário!");

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _repository.UpdateAsync(usuario);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        private async Task<bool> ExistEmailAsync(string email)
        {
            return await _repository.FirstOrDefaultAsync(x => x.Email.Equals(email)) != null;
        }
    }
}
