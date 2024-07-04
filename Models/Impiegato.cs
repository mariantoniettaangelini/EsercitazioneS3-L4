﻿namespace Esercitazione.Models
{
    public class Impiegato
    {
        public int IDImpiegato { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string CodiceFiscale { get; set; }
        public int Eta { get; set; }
        public decimal RedditoMensile {  get; set; }
        public int DetrazioneFiscale { get; set; }

        public IEnumerable<Impiego> Impiego { get; set; }
    }
}
