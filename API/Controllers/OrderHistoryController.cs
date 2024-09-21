using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController(IOrderHistoryService orderHistoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHistoryAsync()
        {
            return Ok(await orderHistoryService.GetOrderHistoriesAsync());
        }
    }
}
