using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day1.Esercizio1.Core.Entities;
using Week10Day1.Esercizio1.Core.Interfaces;

namespace Week10Day1.Esercizio1.Core
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly ICorsoRepository corsiRepo;
        private readonly ICorsoDiLaureaRepository corsoDiLaureaRepo;
        private readonly IImmatricolazioneRepository immRepo;
        private readonly IStudenteRepository studenteRepo;
        private readonly IEsameRepository esamiRepo;

        public BusinessLayer(ICorsoRepository corsi, ICorsoDiLaureaRepository corsiDiLaurea, IImmatricolazioneRepository immatricolazioni, IStudenteRepository studenti, IEsameRepository esami)
        {
            corsiRepo = corsi;
            corsoDiLaureaRepo = corsiDiLaurea;
            immRepo = immatricolazioni;
            studenteRepo = studenti;
            esamiRepo = esami;
        }

        public void AggiungiEsame(Esame esameDaSostenere)
        {
            Studente s = studenteRepo.GetById(esameDaSostenere.IdStudente);
            s.Esami.Add(esameDaSostenere);
            int esameId = esamiRepo.Insert(esameDaSostenere);
            
            
            
        }

        public Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl)
        {
            Immatricolazione imm = new Immatricolazione();
            imm.DataInzio = DateTime.Now;
            imm._CorsoDiLaurea = GetCorsi(cdl);

            int ore = imm.DataInzio.Hour;
            int minuti = imm.DataInzio.Minute;
            var secondi = imm.DataInzio.Second;
            var matricola = String.Concat(ore, minuti, secondi);

            imm.Matricola = Convert.ToInt32(matricola);

            immRepo.Insert(imm);
            imm = immRepo.GetByDate(imm);

            s.IdImmatricolazione = imm.Id;
            s._Immatricolazione = imm;

            studenteRepo.Insert(s);

            return s;
        }


        public List<CorsoDiLaurea> FetchCorsiDiLaurea()
        {
            return corsoDiLaureaRepo.Fetch();
        }

        public CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl)
        {
            List<Corso> corsi = corsiRepo.GetByCorsoDiLaurea(cdl);
            cdl.Corsi = corsi;
            var cfuTotali = corsi.Sum(c => c.CreditiFormativi);
            cdl.Cfu = cfuTotali;

            return cdl;
        }

        public Studente GetStudenteByMatricola(int matricola)
        {
            return studenteRepo.GetByMatricola(matricola);
        }

        public bool RandomEsamePassato()
        {
            return new Random().Next(100) % 2 == 0;
        }

        public void UpdateEsame(Esame esamevalido)
        {
            Studente s = studenteRepo.GetById(esamevalido.IdStudente);
            Esame esameDaCancellare = (s.Esami).Find(e => e.Id == esamevalido.Id);
            s.Esami.Remove(esameDaCancellare);
            s.Esami.Add(esamevalido);
            Corso c = corsiRepo.GetCorsoByNome(esamevalido.Nome);
            s._Immatricolazione.CfuAccumulati += c.CreditiFormativi;
        }

        public bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s)
        {
            var cfuOk = s._Immatricolazione.CfuAccumulati + corsoScelto.CreditiFormativi <= s._Immatricolazione._CorsoDiLaurea.Cfu;
            List<Esame> esami = (s.Esami).Where(e => e.Nome == corsoScelto.Nome).ToList();
            bool pass = false;
            if (cfuOk && !s.LaureaRichiesta)
            {
                if (esami.Count() == 0) { return true; }
                else
                { foreach (var es in esami)
                    {
                        if (es.Passato == false)
                        { pass = true; }
                    }
                    return pass;
                }
            }
            else
                return false;
        }
    }
}
