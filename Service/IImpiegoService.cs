using Esercitazione.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.Common;

namespace Esercitazione.Service
{
    public class ImpiegoService : SqlServerServiceBase, IImpiegoService
    {
        public ImpiegoService(IConfiguration config) : base(config) { }

        public IEnumerable<Impiego> GetListImpieghi(int IDImpiegato)
        {
            List<Impiego> impieghi = new List<Impiego>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = GetCommand("SELECT * FROM Impieghi WHERE IDImpiegato = @IDImpiegato"))
                {
                    cmd.Parameters.Add(new SqlParameter("@id", IDImpiegato));
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            impieghi.Add(new Impiego
                            {
                                IDImpiego = reader.GetInt32(reader.GetOrdinal("IDImpiego")),
                                TipoImpiego = reader.GetString(reader.GetOrdinal("TipoImpiego")),
                                DataAssunzione = reader.GetDateTime(reader.GetOrdinal("DataAssunzione")),
                                IDImpiegato = reader.GetInt32(reader.GetOrdinal("IDImpiegato"))
                            });
                        }
                    }
                }
            }
            return impieghi;
        }
    }

    public interface IImpiegoService
    {
        IEnumerable<Impiego> GetListImpieghi(int IDImpiegato);
    }
}
