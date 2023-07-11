using basecs.Interfaces.Data;
using Microsoft.AspNetCore.Http;

namespace basecs.Data
{
    public class APDWork : IAPDWork
    {
        private readonly APDConnector _session;

        public APDWork(APDConnector session)
        {
            _session = session;
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _session.Transaction?.Dispose();
    }
}
