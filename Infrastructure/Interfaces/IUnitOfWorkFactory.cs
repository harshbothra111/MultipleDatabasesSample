namespace Infrastructure.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create(string connectionStringKey);
    }
}
