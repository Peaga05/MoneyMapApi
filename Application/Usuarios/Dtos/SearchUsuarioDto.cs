using Domain.Base.PagedResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Dtos
{
    public class SearchUsuarioDto : SearchDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
