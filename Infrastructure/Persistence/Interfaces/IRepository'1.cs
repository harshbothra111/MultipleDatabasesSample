using System.Threading.Tasks;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        IQueryable<TEntity> GetAll();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
