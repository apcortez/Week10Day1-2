﻿using System;
using System.Collections.Generic;
using System.Linq;
using Week10Day1.Esercizio1.Core.Entities;
using Week10Day1.Esercizio1.Core.Interfaces;

namespace Week10Day1.Esercizio1.MockRepository
{
    public class CorsiRepository : ICorsoRepository
    {
        public static List<Corso> corsi = new List<Corso>()
        {
            new Corso{Id = 1, Nome ="Analisi Matematica", CreditiFormativi =30, IdCorsoDiLaurea =1},
            new Corso{Id = 2, Nome ="Geometria", CreditiFormativi =40, IdCorsoDiLaurea =1},
            new Corso{Id = 3, Nome ="Logica", CreditiFormativi =25, IdCorsoDiLaurea =1},

            new Corso{Id = 4, Nome ="Fisica Teorica", CreditiFormativi =45, IdCorsoDiLaurea =2},
            new Corso{Id = 5, Nome ="Logica dei vettori", CreditiFormativi =25, IdCorsoDiLaurea =2},
            new Corso{Id = 6, Nome ="Meccanica", CreditiFormativi =40, IdCorsoDiLaurea =2},

            new Corso{Id = 7, Nome ="Database", CreditiFormativi =20, IdCorsoDiLaurea =3},
            new Corso{Id = 8, Nome ="Programmazione Procedurale", CreditiFormativi =35, IdCorsoDiLaurea =3},
            new Corso{Id = 9, Nome ="Sistemi", CreditiFormativi =25, IdCorsoDiLaurea =3},

            new Corso{Id = 10, Nome ="Automatica", CreditiFormativi =30, IdCorsoDiLaurea =4},
            new Corso{Id = 11, Nome ="Geometria Piana", CreditiFormativi =40, IdCorsoDiLaurea =4},
            new Corso{Id = 12, Nome ="Analisi del Software", CreditiFormativi =25, IdCorsoDiLaurea =4},

            new Corso{Id = 13, Nome ="Letteratura Greca", CreditiFormativi =30, IdCorsoDiLaurea =5},
            new Corso{Id = 14, Nome ="Letteratura Latina", CreditiFormativi =40, IdCorsoDiLaurea =5},
            new Corso{Id = 15, Nome ="Grammatica", CreditiFormativi =25, IdCorsoDiLaurea =5},
        };

        public List<Corso> Fetch()
        {
            return corsi;
        }

        public List<Corso> GetByCorsoDiLaurea(CorsoDiLaurea cdl)
        {
           return corsi.Where(c => c.IdCorsoDiLaurea == cdl.Id).ToList();
        }

        public Corso GetCorsoByNome(string nome)
        {
            return corsi.Where(c => c.Nome == nome).FirstOrDefault();
        }

        public int Insert(Corso item)
        {
            throw new NotImplementedException();
        }
    }
}
