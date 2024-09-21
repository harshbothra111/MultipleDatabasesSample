namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}
