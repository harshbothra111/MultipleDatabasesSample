using Infrastructure.Databases.ProductsDatabase.Interfaces;
using Infrastructure.Databases.ProductsDatabase.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Databases.ProductsDatabase
{
    public class ProductUnitOfWork(ProductDbContext context) : UnitOfWork(context)
    {
        private IProductRepository? _productRepository;
        private ICategoryRepository? _categoryRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                _productRepository ??= new ProductRepository(context);
                return _productRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                _categoryRepository ??= new CategoryRepository(context);
                return _categoryRepository;
            }
        }
    }
}
