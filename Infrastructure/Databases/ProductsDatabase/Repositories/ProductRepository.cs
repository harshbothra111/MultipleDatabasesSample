using Infrastructure.Databases.ProductsDatabase.Interfaces;
using Infrastructure.Databases.ProductsDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.ProductsDatabase.Repositories
{
    internal class ProductRepository(ProductDbContext context) : Repository<Product>(context), IProductRepository
    {
    }
}
