using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Batalha
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime dtInicio { get; set; }
        public DateTime dtFim { get; set; }
        public List<HeroiBatalha> heroisBatalhas { get; set; }
    }
}