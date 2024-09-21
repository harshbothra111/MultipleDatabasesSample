using Infrastructure.Databases.CustomerDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.CustomerDatabase.Repositories
{
    public class AddressRepository(CustomerDbContext context) : Repository<Address>(context)
    {
    }
}