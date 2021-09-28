using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day1
{
    public abstract class Padre
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Stampa()
        {
            return $"{Id} - {Nome}";
        }

        public abstract void CalcolaEta(); // I figli devono implementare il metodo

        public virtual string Saluta() //Do la possibilità di eseguire l'override
        {
            return $"Ciao a tutti";
        }
    }
}
