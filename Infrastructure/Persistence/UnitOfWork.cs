using Infrastructure.Interfaces;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    internal class UnitOfWork(DbContext context) : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = [];

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (!_repositories.ContainsKey(typeof(TEntity)))
            {
                _repositories[typeof(TEntity)] = new Repository<TEntity>(context);
            }
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
