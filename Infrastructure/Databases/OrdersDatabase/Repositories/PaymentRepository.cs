using Infrastructure.Databases.OrdersDatabase.Interfaces;
using Infrastructure.Databases.OrdersDatabase.Models;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Databases.OrdersDatabase.Repositories
{
    internal class PaymentRepository(OrderDbContext context) : Repository<Payment>(context), IPaymentRepository
    {
    }
}
