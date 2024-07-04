using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Esercitazione.Service
{
    public abstract class ServiceBase
    {
        public const string DDL =
            "CREATE TABLE [dbo].[Impiegato] (" +
            "[IDImpiegato] INT IDENTITY (1, 1) NOT NULL," +
            "[Cognome] NVARCHAR (50) NOT NULL," +
            "[Nome] NVARCHAR (50) NOT NULL," +
            "[CodiceFiscale] NCHAR (16) NOT NULL," +
            "[Eta] INT NOT NULL," +
            "[RedditoMensile] DECIMAL (18, 2) NOT NULL," +
            "[DetrazioneFiscale] INT NOT NULL" +
            ");" +
            "CREATE TABLE [dbo].[Impiego] (" +
            "[IDImpiego] INT IDENTITY (1, 1) NOT NULL," +
            "[TipoImpiego] NVARCHAR (50) NOT NULL," +
            "[DataAssunzione] DATETIME2 (7) DEFAULT (getdate())," +
            "[IDImpiegato] INT NOT NULL" +
            ");";

        public void CreateMetadata()
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = GetCommand(DDL);
            cmd.ExecuteNonQuery();
        }

        protected abstract DbConnection GetConnection();
        protected abstract DbCommand GetCommand(string commandText);
    }
}