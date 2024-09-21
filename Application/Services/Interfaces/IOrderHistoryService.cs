using Domain.Models;

namespace Application.Services.Interfaces
{
    public interface IOrderHistoryService
    {
        Task<List<OrderHistory>> GetOrderHistoriesAsync();
    }
}
