using Domain.Base.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace Application.Usuarios.Dtos
{
    public class UpdateUsuarioDto : FullEntity
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo e-mail deve ter no máximo 100 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [StringLength(maximumLength: 16, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 16 caracteres")]
        public string Senha { get; set; }
    }
}
