using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class HeroiBatalha
    {
        public int heroiId { get; set; }
        public Heroi heroi { get; set; }
        public int batalhaId { get; set; }
        public Batalha batalha { get; set; }
    }
}