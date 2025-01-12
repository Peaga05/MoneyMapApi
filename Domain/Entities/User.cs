using Domain.Base.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : FullEntity
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo e-mail deve ter no máximo 100 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Password { get; set; }
    }
}
