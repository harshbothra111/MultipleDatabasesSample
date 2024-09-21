using Application.Interfaces;
using Domain.Models;
using Infrastructure.Databases.CustomerDatabase;
using Infrastructure.Databases.OrdersDatabase;
using Infrastructure.Databases.ProductsDatabase;

namespace Application
{
    internal class OrderHistoryService(CustomerUnitOfWork customerUnitOfWork, ProductUnitOfWork productUnitOfWork, OrderUnitOfWork orderUnitOfWork) : IOrderHistoryService
    {
        public async Task<List<OrderHistory>> GetOrderHistoriesAsync()
        {
            var orders = orderUnitOfWork.OrderRepository.GetAll();
            var customers
            var query = from order in orders
                        join customer in customerContext.Customers
                            on order.CustomerID equals customer.CustomerID
                        join address in customerContext.Addresses
                            on customer.CustomerID equals address.CustomerID into customerAddresses
                        from address in customerAddresses.DefaultIfEmpty() // Left join for addresses
                        join orderDetail in ordersContext.OrderDetails
                            on order.OrderID equals orderDetail.OrderID
                        join product in productsContext.Products
                            on orderDetail.ProductID equals product.ProductID
                        join payment in ordersContext.Payments
                            on order.OrderID equals payment.OrderID into orderPayments
                        from payment in orderPayments.DefaultIfEmpty() // Left join for payments
                        select new
                        {
                            // Customer details
                            CustomerID = customer.CustomerID,
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            Email = customer.Email,
                            Street = address != null ? address.Street : null,
                            City = address != null ? address.City : null,
                            State = address != null ? address.State : null,

                            // Order details
                            OrderID = order.OrderID,
                            OrderDate = order.OrderDate,
                            TotalAmount = order.TotalAmount,
                            Status = order.Status,

                            // Product details
                            ProductName = product.ProductName,
                            ProductDescription = product.Description,
                            Quantity = orderDetail.Quantity,
                            UnitPrice = orderDetail.UnitPrice,

                            // Payment details
                            PaymentDate = payment != null ? payment.PaymentDate : (DateTime?)null,
                            PaymentAmount = payment != null ? payment.PaymentAmount : (decimal?)null,
                            PaymentMethod = payment != null ? payment.PaymentMethod : null
                        };

        }
    }
}
