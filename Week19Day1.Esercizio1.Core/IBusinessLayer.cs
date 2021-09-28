using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day1.Esercizio1.Core.Entities;

namespace Week10Day1.Esercizio1.Core
{
    public interface IBusinessLayer
    {
        List<CorsoDiLaurea> FetchCorsiDiLaurea();
        CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl);

        Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl);
        bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s);
        void AggiungiEsame(Esame esameDaSostenere);
        Studente GetStudenteByMatricola(int matricola);
        bool RandomEsamePassato();
        void UpdateEsame(Esame esamevalido);
    }
}
