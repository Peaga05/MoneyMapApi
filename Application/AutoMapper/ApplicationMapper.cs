using Application.Usuarios.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //Usuário
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<UpdateUsuarioDto, Usuario>();
        }
    }
}
