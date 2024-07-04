using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Esercitazione.Service
{
    public class SqlServerServiceBase : ServiceBase
    {
        private SqlConnection _connection;

        public SqlServerServiceBase(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("Azienda"));
        }

        protected override DbCommand GetCommand(string commandText)
        {
            return new SqlCommand(commandText, _connection);
        }

        protected override DbConnection GetConnection()
        {
            return _connection;
        }
    }
}

