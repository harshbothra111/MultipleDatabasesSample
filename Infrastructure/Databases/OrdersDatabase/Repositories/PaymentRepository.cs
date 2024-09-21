using Infrastructure.Databases.OrdersDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.OrdersDatabase.Repositories
{
    public class PaymentRepository(OrderDbContext context) : Repository<Payment>(context)
    {
    }
}
