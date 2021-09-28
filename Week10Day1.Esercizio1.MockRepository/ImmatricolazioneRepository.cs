using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day1.Esercizio1.Core.Entities;
using Week10Day1.Esercizio1.Core.Interfaces;

namespace Week10Day1.Esercizio1.MockRepository
{
    public class ImmatricolazioneRepository : IImmatricolazioneRepository
    {
        public static List<Immatricolazione> immatricolazioni = new List<Immatricolazione>();
        public List<Immatricolazione> Fetch()
        {
            throw new NotImplementedException();
        }

        public Immatricolazione GetByDate(Immatricolazione imm)
        {
            return immatricolazioni.Where(i => i.DataInzio == imm.DataInzio).SingleOrDefault();
        }

        public int Insert(Immatricolazione item)
        {
            if (immatricolazioni.Count() == 0)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = immatricolazioni.Max(i => i.Id) + 1;
            }
            immatricolazioni.Add(item);
            return item.Id;

        }
    }
}
