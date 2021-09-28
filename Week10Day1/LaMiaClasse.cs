using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day1
{
    public class LaMiaClasse
    {
        //Campi
        public int count;
        public string nome;
        public int id;

        //Proprietà
        public int Id { get; set; }
        public int Eta { get; set; }

        public int IdEsplicito
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Nome { get; private set; }
        public string Cognome { private get; set; }

        //Costruttori
        //Se non definisco costruttori, il costruttore base esiste implicitamente
        public LaMiaClasse(int id)
        {
            Id = id;
        }
        public LaMiaClasse()
        {

        }

        //Metodi
        public string StampaNome()
        {
            return $"{Nome}";

        }

        //Distruttore
        ~LaMiaClasse()
        {
            //lmc = null;
        }

    }
}
