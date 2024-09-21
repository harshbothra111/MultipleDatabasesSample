using Infrastructure.Databases.OrdersDatabase.Interfaces;
using Infrastructure.Databases.OrdersDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.OrdersDatabase.Repositories
{
    internal class OrderDetailRepository(OrderDbContext context) : Repository<OrderDetail>(context), IOrderDetailRepository
    {
    }
}
