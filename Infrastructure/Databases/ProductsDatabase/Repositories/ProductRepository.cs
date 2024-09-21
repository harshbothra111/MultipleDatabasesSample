using Infrastructure.Databases.ProductsDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.ProductsDatabase.Repositories
{
    public class ProductRepository(ProductDbContext context) : Repository<Product>(context)
    {
    }
}
