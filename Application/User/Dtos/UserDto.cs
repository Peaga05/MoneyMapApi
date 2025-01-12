using Domain.Base.BaseEntity;

namespace Application.Usuarios.Dtos
{
    public class UserDto : FullEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
