using Infrastructure.Databases.ProductsDatabase.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Databases.ProductsDatabase
{
    public class ProductUnitOfWork(ProductDbContext context) : UnitOfWork(context)
    {
        private ProductRepository? _productRepository;
        private CategoryRepository? _categoryRepository;

        public ProductRepository ProductRepository
        {
            get
            {
                _productRepository ??= new ProductRepository(context);
                return _productRepository;
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                _categoryRepository ??= new CategoryRepository(context);
                return _categoryRepository;
            }
        }
    }
}
