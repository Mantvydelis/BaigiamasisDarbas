using Microsoft.AspNetCore.Mvc;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using Serilog;

namespace Parduotuve.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduktaiController : Controller
    {
        private readonly IProduktaiService _produktaiService;

        public ProduktaiController(IProduktaiService produktaiService)
        {
            _produktaiService = produktaiService;
            Log.Information("ProduktaiController started");
        }


        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> Index()
        {
            Log.Information("GetAllProducts service started");
            var allProducts = await _produktaiService.GetAllProducts();

            Log.Information("GetAllProduct worked and shows all Products:{@AllProducts}", allProducts);
            return Ok(allProducts);
        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Produktas produktas)
        {
            Log.Information("AddProduct service started");
            try
            {
                await _produktaiService.AddProduct(produktas);
                Log.Information("Product added successfully: {@Produktas}", produktas);
                return Ok();
            }
            catch
            {
                Log.Error("Product was not added");
                return Problem();
            }

        }



        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int produktoId)
        {
            Log.Information("GetProductById service started");
            try
            {
                var foundProduct = await _produktaiService.GetProductById(produktoId);
                Log.Information("Product found successfully: {@FoundProduct}", foundProduct);
                return Ok(foundProduct);

            }
            catch
            {
                Log.Error("Product was not found");
                return Problem();

            }

        }

        [HttpPatch("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Produktas produktas)
        {
            Log.Information("UpdateProduct service started");
            try
            {
                await _produktaiService.UpdateProduct(produktas);
                Log.Information("Product updated successfully:{@Produktas}", produktas);
                return Ok(produktas);

            }
            catch
            {
                Log.Error("There was a problem with updating");
                return Problem();
            }

        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProductById(int produktoId)
        {
            Log.Information("DeleteProduct service started");
            await _produktaiService.DeleteProductById(produktoId);
            Log.Information("Product deleted successfully");
            return Ok();
        }



    }
}
