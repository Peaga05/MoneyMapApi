using Domain.Base.BaseEntity;

namespace Application.Usuarios.Dtos
{
    public class UsuarioDto : FullEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
