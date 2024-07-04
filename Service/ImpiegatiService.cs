using Esercitazione.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Esercitazione.Service
{
    public class ImpiegatiService : SqlServerServiceBase, IImpiegatoService
    {
        public ImpiegatiService(IConfiguration config) : base(config) { }

        public Impiegato GetImpiegati(int IDImpiegato)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var command = GetCommand("SELECT * FROM Impiegati WHERE IDImpiegato = @id");
                command.Parameters.Add(new SqlParameter("@IDImpiegato", IDImpiegato));

                var reader = command.ExecuteReader();
                {
                    if (reader.Read())
                    {
                        return new Impiegato
                        {
                            IDImpiegato = reader.GetInt32(reader.GetOrdinal("IDImpiegato")),
                            Cognome = reader.GetString(reader.GetOrdinal("Cognome")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            CodiceFiscale = reader.GetString(reader.GetOrdinal("CodiceFiscale")),
                            Eta = reader.GetInt32(reader.GetOrdinal("Eta")),
                            RedditoMensile = reader.GetDecimal(reader.GetOrdinal("RedditoMensile")),
                            DetrazioneFiscale = reader.GetInt32(reader.GetOrdinal("DetrazioneFiscale"))
                        };
                    }
                    else
                    {
                        return null; 
                    }
                }
            }
        }
    }
}
