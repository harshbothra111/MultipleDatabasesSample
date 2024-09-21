using Infrastructure.Databases.CustomerDatabase.Interfaces;
using Infrastructure.Databases.CustomerDatabase.Models;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Databases.CustomerDatabase.Repositories
{
    internal class CustomerRepository(CustomerDbContext context) : Repository<Customer>(context), ICustomerRepository
    {
        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
