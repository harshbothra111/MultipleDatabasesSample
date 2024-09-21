using Infrastructure.Databases.ProductsDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.ProductsDatabase.Repositories
{
    public class CategoryRepository(ProductDbContext context) : Repository<Category>(context)
    {
    }
}
