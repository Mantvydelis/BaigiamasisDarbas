using Microsoft.AspNetCore.Mvc;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using Parduotuve.Core.Services;

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
        }

        [HttpGet("GetAllOders")]
        public async Task<IActionResult> Index()
        {
            var allOrders = await _uzsakymaiService.GetAllOrders();
            return Ok(allOrders);
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(Uzsakymas uzsakymas)
        {
            try
            {
                await _uzsakymaiService.AddOrder(uzsakymas);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetorderById(int uzsakymoId)
        {
            try
            {
                var foundOrder = await _uzsakymaiService.GetOrderById(uzsakymoId);
                return Ok(foundOrder);

            }
            catch
            {

                return Problem();

            }

        }

        [HttpPatch("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(Uzsakymas uzsakymas)
        {
            try
            {
                await _uzsakymaiService.UpdateOrder(uzsakymas);
                return Ok(uzsakymas);

            }
            catch
            {
                return Problem();
            }

        }

        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrderById(int uzsakymoId)
        {
            await _uzsakymaiService.DeleteOrderById(uzsakymoId);
            return Ok();
        }





    }
}
