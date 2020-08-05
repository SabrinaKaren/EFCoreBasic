using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class IdentidadeSecreta
    {
        public int id { get; set; }
        public String nomeReal { get; set; }
        public int heroiId { get; set; }
        public Heroi heroi { get; set; }
    }
}