using Esercitazione.Models;

namespace Esercitazione.Service
{
    public class ImpiegoService : SqlServerServiceBase, IImpiegoService
    {
        public ImpiegoService(IConfiguration config) : base(config) { }
    }

    public IEnumerable<Impiego> GetListImpieghi(int IDImpiegato)
    {
        using var conn = GetConnection();
        conn.Open();
        using var cmd = GetCommand()
    }
}
