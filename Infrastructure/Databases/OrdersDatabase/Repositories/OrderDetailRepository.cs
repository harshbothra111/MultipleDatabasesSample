using Infrastructure.Databases.OrdersDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.OrdersDatabase.Repositories
{
    public class OrderDetailRepository(OrderDbContext context) : Repository<OrderDetail>(context)
    {
    }
}
