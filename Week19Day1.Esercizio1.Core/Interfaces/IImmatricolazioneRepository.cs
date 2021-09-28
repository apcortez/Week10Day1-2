using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day1.Esercizio1.Core.Entities;

namespace Week10Day1.Esercizio1.Core.Interfaces
{
    public interface IImmatricolazioneRepository: IRepository<Immatricolazione>
    {
        Immatricolazione GetByDate(Immatricolazione imm);
    }
}
