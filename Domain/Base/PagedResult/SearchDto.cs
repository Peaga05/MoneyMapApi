using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base.PagedResult
{
    public class SearchDto
    {
        public int Take { get; set; }
        public int Skip { get; set; }

        public SearchDto()
        {
            Skip = 0;
            Take = 10;
        }
    }
}
