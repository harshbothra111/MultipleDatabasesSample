using Infrastructure.Databases.CustomerDatabase.Interfaces;
using Infrastructure.Databases.CustomerDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.CustomerDatabase.Repositories
{
    internal class AddressRepository(CustomerDbContext context) : Repository<Address>(context), IAddressRepository
    {
    }
}