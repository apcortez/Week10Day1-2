using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day1.Esercizio1.Core.Entities
{
    public class Immatricolazione
    {
        public int Id { get; set; }
        public int Matricola { get; set; }
        public DateTime DataInzio { get; set; }
        public CorsoDiLaurea _CorsoDiLaurea { get; set; }
        public bool FuoriCorso { get; set; }
        public int CfuAccumulati { get; set; }
    }
}
