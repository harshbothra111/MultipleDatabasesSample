using Infrastructure.Databases.OrdersDatabase.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Databases.OrdersDatabase
{
    public class OrderUnitOfWork(OrderDbContext context) : UnitOfWork(context)
    {
        private OrderDetailRepository? _orderDetailRepository;
        private OrderRepository? _orderRepository;
        private PaymentRepository? _paymentRepository;

        public OrderDetailRepository OrderDetailRepository
        {
            get
            {
                _orderDetailRepository ??= new OrderDetailRepository(context);
                return _orderDetailRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                _orderRepository ??= new OrderRepository(context);
                return _orderRepository;
            }
        }

        public PaymentRepository PaymentRepository
        {
            get
            {
                _paymentRepository ??= new PaymentRepository(context);
                return _paymentRepository;
            }
        }
    }
}
