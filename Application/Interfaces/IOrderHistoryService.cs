using Domain.Models;

namespace Application.Interfaces
{
    public interface IOrderHistoryService
    {
        Task<List<OrderHistory>> GetOrderHistoriesAsync();
    }
}
