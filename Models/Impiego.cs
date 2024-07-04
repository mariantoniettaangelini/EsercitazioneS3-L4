namespace Esercitazione.Models
{
    public class Impiego
    {
        public int IDImpiego { get; set; }
        public string TipoImpiego { get; set; }
        public DateTime DataAssunzione { get; set; }
        public int IDImpiegato { get; set; }

    }
}
