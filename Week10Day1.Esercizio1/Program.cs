using System;
using System.Collections.Generic;
using System.Linq;
using Week10Day1.Esercizio1.Core;
using Week10Day1.Esercizio1.Core.Entities;
using Week10Day1.Esercizio1.MockRepository;

namespace Week10Day1.Esercizio1
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new CorsiRepository(), new CorsoDiLaureaRepository(), 
                                                                      new ImmatricolazioneRepository(), new StudenteRepository(),
                                                                      new EsameRepository());
        static void Main(string[] args)
        {

            bool continuare = true;
            int scelta;
            bool uscita = true;
            Studente s = new Studente();

            do
            {
                do
                {
                    Console.WriteLine("Premi 1 per immatricolarti");
                    Console.WriteLine("Premi 2 per accedere");
                    Console.WriteLine("Premi 3 per iscriverti ad un esame");
                    Console.WriteLine("Premi 4 per guardare il risultato di un esame");
                    Console.WriteLine("Premi 0 per uscire");

                    continuare = int.TryParse(Console.ReadLine(), out scelta);
                } while (!continuare);

                switch (scelta)
                {
                    case 1:
                        s = Immatricolazione();
                        break;
                    case 2:
                        s = Accedi();
                        break;
                    case 3:
                        IscriversiAdEsame(s);
                        break;
                    case 4:
                        ViewRisultatoEsame(s);
                        break;
                    case 0:
                        uscita = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non corretta");
                        break;
                }
            } while (uscita);
        }

        private static Studente Accedi()
        {
            int matricola;
            Studente s;
            do
            {
                Console.WriteLine("Inserisci la matricola: ");
                matricola = int.Parse(Console.ReadLine());
                s = bl.GetStudenteByMatricola(matricola);
            } while (s == null);

            Console.WriteLine("Accesso avvenuto con successo.\n");
            Console.WriteLine($"Matricola: {s.Id}\nNome: {s.Nome}, Cognome: {s.Cognome} \nIscrizione per laurea in {s._Immatricolazione._CorsoDiLaurea.Nome}, CFU Totali: {s._Immatricolazione._CorsoDiLaurea.Cfu}" +
                $"\nCFU Accumulati: {s._Immatricolazione.CfuAccumulati}");
            return s;
        }

        private static void ViewRisultatoEsame(Studente s)
        {
            Console.WriteLine("Esami: ");
            foreach (var esame in s.Esami)
            {
                Console.WriteLine(esame.Id + " - " + esame.Nome);

            }
            Console.WriteLine("Quale esame vuoi visualizzare? Inserisci il numero di esame.");
            int esameScelto = int.Parse(Console.ReadLine());
            Esame esamevalido = (s.Esami).Where(e => e.Id == esameScelto).FirstOrDefault();
            if (esamevalido != null) 
            {
                bool esamePassato = bl.RandomEsamePassato();
                esamevalido.Passato = esamePassato;
                
                if (esamevalido.Passato)
                {

                    bl.UpdateEsame(esamevalido); // update
                }
                Console.WriteLine($"Matricola: {esamevalido.IdStudente} - Esame: {esamevalido.Nome} - Passato: {esamevalido.Passato}");
            }
         

           
        }

        private static void IscriversiAdEsame(Studente s)
        {
            var immatricolazione = s._Immatricolazione;
            var corsoDiLaurea = immatricolazione._CorsoDiLaurea;
            var corsi = corsoDiLaurea.Corsi;

            foreach (var corso in corsi)
            {
                Console.WriteLine(corso.Print());
            }
            string esame = String.Empty;
            Corso corsoScelto;
            do
            {
                Console.WriteLine("A quale esame vuoi iscriverti?");
                esame = Console.ReadLine();
                corsoScelto = corsi.Where(c => c.Nome == esame).SingleOrDefault();
            } while (corsoScelto == null);

            bool possibileIscriversi = bl.VerificaCfuPerIscrizioneEsame(corsoScelto, s);
            if (possibileIscriversi)
            {
                Esame esameDaSostenere = new Esame();
                esameDaSostenere.Nome = corsoScelto.Nome;
                esameDaSostenere.Passato = false;
                esameDaSostenere.IdStudente = s.Id;
                bl.AggiungiEsame(esameDaSostenere);
                Console.WriteLine($"Matricola {s.IdImmatricolazione} iscritto all'esame {esameDaSostenere.Nome}  n. {esameDaSostenere.Id} con successo");

                

            }
            else
            {
                Console.WriteLine("Non è possibile sostenere un esame per eccesso di crediti o esame già sostenuta con esito positivo.");
            }
        }

        private static Studente Immatricolazione()
        {
            string nome = String.Empty;
            bool continuare = true;

            do
            {
                Console.WriteLine("Inserisci il tuo nome");
                nome = Console.ReadLine();
                if (!String.IsNullOrEmpty(nome))
                    continuare = false;
            } while (continuare);

            string cognome = String.Empty;
            continuare = true;

            do
            {
                Console.WriteLine("Inserisci il tuo cognome");
                cognome = Console.ReadLine();
                if (!String.IsNullOrEmpty(cognome))
                    continuare = false;
                //else
                //    continuare = true;
            } while (continuare);

            int annoNascita;
            continuare = true;

            do
            {
                Console.WriteLine("Inserisci l'anno di nascita");
                continuare = int.TryParse(Console.ReadLine(), out annoNascita);
            } while (!continuare);

            Studente s = new Studente(nome, cognome, annoNascita);

            List<CorsoDiLaurea> corsiDiLaurea = bl.FetchCorsiDiLaurea();
            foreach (var corsoDiLaurea in corsiDiLaurea)
            {
                Console.WriteLine(corsoDiLaurea.Print());
            }

            var nomeCdL = Console.ReadLine();
            // Lo posso fare qui perchè ho fatto una fetch prima
            CorsoDiLaurea cdl = corsiDiLaurea.Where(c => c.Nome == nomeCdL).SingleOrDefault();

            s = bl.CreaImmatricolazione(s, cdl);

            return s;
        }
    }

}
