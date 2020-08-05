using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Arma
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Heroi heroi { get; set; }
        public int heroiId { get; set; }
    }
}