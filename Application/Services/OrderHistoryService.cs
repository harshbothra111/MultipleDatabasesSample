using Application.Services.Interfaces;
using Domain.Models;
using Infrastructure.Databases.CustomerDatabase;
using Infrastructure.Databases.OrdersDatabase;
using Infrastructure.Databases.ProductsDatabase;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    internal class OrderHistoryService(CustomerUnitOfWork customerUnitOfWork, ProductUnitOfWork productUnitOfWork, OrderUnitOfWork orderUnitOfWork) : IOrderHistoryService
    {
        public async Task<List<OrderHistory>> GetOrderHistoriesAsync()
        {
            var orders = await orderUnitOfWork.OrderRepository.GetAll().ToListAsync();
            var customers = await customerUnitOfWork.CustomerRepository.GetAll().ToListAsync();
            var addresses = await customerUnitOfWork.AddressRepository.GetAll().ToListAsync();
            var orderDetails = await orderUnitOfWork.OrderDetailRepository.GetAll().ToListAsync();
            var products = await productUnitOfWork.ProductRepository.GetAll().ToListAsync();
            var payments = await orderUnitOfWork.PaymentRepository.GetAll().ToListAsync();

            var query = from order in orders
                        join customer in customers
                            on order.CustomerId equals customer.CustomerId
                        join address in addresses
                            on customer.CustomerId equals address.CustomerId into customerAddresses
                        from address in customerAddresses.DefaultIfEmpty() // Left join for addresses
                        join orderDetail in orderDetails
                            on order.OrderId equals orderDetail.OrderId
                        join product in products
                            on orderDetail.ProductId equals product.ProductId
                        join payment in payments
                            on order.OrderId equals payment.OrderId into orderPayments
                        from payment in orderPayments.DefaultIfEmpty() // Left join for payments
                        select new OrderHistory
                        {
                            // Customer details
                            CustomerId = customer.CustomerId,
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            Email = customer.Email,
                            Street = address.Street,
                            City = address.City,
                            State = address.State,

                            // Order details
                            OrderId = order.OrderId,
                            OrderDate = order.OrderDate,
                            TotalAmount = order.TotalAmount,
                            Status = order.Status,

                            // Product details
                            ProductName = product.ProductName,
                            ProductDescription = product.Description,
                            Quantity = orderDetail.Quantity,
                            UnitPrice = orderDetail.UnitPrice,

                            // Payment details
                            PaymentDate = payment?.PaymentDate,
                            PaymentAmount = payment?.PaymentAmount ?? 0,
                            PaymentMethod = payment?.PaymentMethod
                        };

            return query.ToList();
        }
    }
}
