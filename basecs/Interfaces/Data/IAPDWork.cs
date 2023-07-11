namespace basecs.Interfaces.Data
{
    public interface IAPDWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
