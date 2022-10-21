namespace VivaioInCloud.Common.Abstraction.Repositories
{
    public interface IUnitOfWork
    {
        IUnitOfWorkScope BeginScope();
    }

    public interface IUnitOfWorkScope : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
