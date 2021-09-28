using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day1.Esercizio1.Core.Entities;
using Week10Day1.Esercizio1.Core.Interfaces;

namespace Week10Day1.Esercizio1.MockRepository
{
    public class CorsoDiLaureaRepository : ICorsoDiLaureaRepository
    {
        public static List<CorsoDiLaurea> corsiDiLaurea = new List<CorsoDiLaurea>()
        {
            new CorsoDiLaurea{ Id =1, Nome = "Matematica", AnniDiCorso = 3, Cfu = 100},
            new CorsoDiLaurea{ Id =2, Nome = "Fisica", AnniDiCorso = 3, Cfu = 100},
            new CorsoDiLaurea{ Id =3, Nome = "Informatica", AnniDiCorso = 3, Cfu = 100},
            new CorsoDiLaurea{ Id =4, Nome = "Ingegneria", AnniDiCorso = 3, Cfu = 100},
            new CorsoDiLaurea{ Id =5, Nome = "Lettere", AnniDiCorso = 3, Cfu = 100},
        };


        public List<CorsoDiLaurea> Fetch()
        {
            return corsiDiLaurea;
        }

        public int Insert(CorsoDiLaurea item)
        {
            throw new NotImplementedException();
        }
    }
}
