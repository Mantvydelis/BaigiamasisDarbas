using Microsoft.AspNetCore.Mvc;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using Parduotuve.Core.Services;
using Serilog;

namespace Parduotuve.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UzsakymaiController : Controller
    {

        private readonly IUzsakymaiService _uzsakymaiService;

        public UzsakymaiController(IUzsakymaiService uzsakymaiService)
        {
            _uzsakymaiService = uzsakymaiService;
            Log.Information("UzsakymaiController started");
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> Index()
        {
            Log.Information("GetAllOrders service started");
            var allOrders = await _uzsakymaiService.GetAllOrders();
            Log.Information("GetAllProduct worked and shows all Orders:{@AllOrders}", allOrders);
            return Ok(allOrders);
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(Uzsakymas uzsakymas)
        {
            Log.Information("AddProduct service started");
            try
            {
                await _uzsakymaiService.AddOrder(uzsakymas);
                Log.Information("Order added successfully: {@Uzsakymas}", uzsakymas);
                return Ok();
            }
            catch
            {
                Log.Error("Order was not added");
                return Problem();
            }

        }

        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetorderById(int uzsakymoId)
        {
            Log.Information("GetOrderById service started");
            try
            {
                var foundOrder = await _uzsakymaiService.GetOrderById(uzsakymoId);
                Log.Information("Order found successfully: {@FoundOrder}", foundOrder);
                return Ok(foundOrder);

            }
            catch
            {
                Log.Error("Order was not found");
                return Problem();

            }

        }

        [HttpPatch("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(Uzsakymas uzsakymas)
        {
            Log.Information("UpdateOrder service started");
            try
            {
                await _uzsakymaiService.UpdateOrder(uzsakymas);
                Log.Information("Order updated successfully:{@Uzsakymas}", uzsakymas);
                return Ok(uzsakymas);

            }
            catch
            {
                Log.Error("There was a problem with updating");
                return Problem();
            }

        }

        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrderById(int uzsakymoId)
        {
            Log.Information("DeleteOrder service started");
            await _uzsakymaiService.DeleteOrderById(uzsakymoId);
            Log.Information("Order deleted successfully");
            return Ok();
        }





    }
}
