using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Model
{
    public class Heroi
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int batalhaId { get; set; }
        public Batalha batalha { get; set; }
    }
}