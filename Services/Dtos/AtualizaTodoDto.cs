using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class AtualizaTodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Complete { get; set; }
    }
}
