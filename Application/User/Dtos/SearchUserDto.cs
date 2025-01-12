using Domain.Base.PagedResult;

namespace Application.Usuarios.Dtos
{
    public class SearchUserDto : SearchDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
