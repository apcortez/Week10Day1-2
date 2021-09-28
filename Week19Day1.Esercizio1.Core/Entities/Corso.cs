using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day1.Esercizio1.Core.Entities
{
    public class Corso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CreditiFormativi { get; set; }

        public int IdCorsoDiLaurea { get; set; }

        public string Print()
        {
            return $"{Nome} per {CreditiFormativi} cfu";
        }
    }

        //CdL -> Matematica
        //AnniCorso -> 3
        //CFU -> Somma dei corsi

        //Corsi
        //* Geometria - 30
        //* Analisi Matematica - 40
        //* Logica  - 30
}
