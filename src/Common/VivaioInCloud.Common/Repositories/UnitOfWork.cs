using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using VivaioInCloud.Common.Abstraction.Repositories;

namespace VivaioInCloud.Common.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork
        where T : DbContext
    {
        // reference for transaction in ef core
        // https://docs.microsoft.com/en-us/ef/core/saving/transactions

        private T context;

        public UnitOfWork(T context)
        {
            this.context = context;
        }

        public IUnitOfWorkScope BeginScope()
        {
            if (context.Database.CurrentTransaction != null)
                return new NestedUnitOfWorkScope();

            return new UnitOfWorkScope(context.Database.BeginTransaction());
        }

        public async Task<IUnitOfWorkScope> BeginScopeAsync()
        {
            return new UnitOfWorkScope(await context.Database.BeginTransactionAsync());
        }

        internal class UnitOfWorkScope : IUnitOfWorkScope
        {
            private IDbContextTransaction dbContextTransaction;

            public UnitOfWorkScope(IDbContextTransaction dbContextTransaction)
            {
                this.dbContextTransaction = dbContextTransaction;
            }

            public void Commit()
            {
                dbContextTransaction.Commit();
            }

            public void Rollback()
            {
                dbContextTransaction.Rollback();
            }

            public void Dispose()
            {
                dbContextTransaction.Dispose();
            }

        }

        internal class NestedUnitOfWorkScope : IUnitOfWorkScope
        {
            public void Commit()
            {
            }

            public void Dispose()
            {
            }

            public void Rollback()
            {
                throw new InvalidOperationException("Cannot explicitly rollback in nested unit of works");
            }
        }
    }
}
