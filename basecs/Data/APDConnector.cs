using Microsoft.Data.SqlClient;
using System.Data;
using basecs.Helpers.RumtimeStings;

namespace basecs.Data
{
    public class APDConnector
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public APDConnector()
        {
            Connection = new SqlConnection(RumtimeSettings.ConnectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
