using Infrastructure.Databases.OrdersDatabase.Interfaces;
using Infrastructure.Databases.OrdersDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.OrdersDatabase.Repositories
{
    public class OrderRepository(OrderDbContext context) : Repository<Order>(context), IOrderRepository
    {
    }
}
