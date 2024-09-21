using Infrastructure.Databases.CustomerDatabase.Models;

namespace Infrastructure.Databases.CustomerDatabase.Interfaces
{
    internal interface ICustomerRepository
    {
        Task<Customer?> GetCustomerByEmailAsync(string email);
    }
}
