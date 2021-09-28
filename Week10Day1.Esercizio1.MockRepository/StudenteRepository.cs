using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day1.Esercizio1.Core.Entities;
using Week10Day1.Esercizio1.Core.Interfaces;

namespace Week10Day1.Esercizio1.MockRepository
{
    public class StudenteRepository : IStudenteRepository
    {
        public static List<Studente> studenti = new List<Studente>();
        public List<Studente> Fetch()
        {
            throw new NotImplementedException();
        }

        public Studente GetById(int id)
        {
            return studenti.Where(s => s.Id == id).FirstOrDefault();
        }

        public Studente GetByMatricola(int matricola)
        {
            return studenti.Where(s => s.IdImmatricolazione == matricola).FirstOrDefault();
        }

        public int Insert(Studente item)
        {
            if (studenti.Count == 0)
                item.Id = 1;
            else
                item.Id = studenti.Max(s => s.Id) + 1;

            studenti.Add(item);
            return item.Id;
        }

    }
}
