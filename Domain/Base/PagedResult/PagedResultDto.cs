using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base.PagedResult
{
    public class PagedResultDto<T>
    {
        public int Quantidade {  get; set; }
        public List<T> Result { get; set; }
    }
}
