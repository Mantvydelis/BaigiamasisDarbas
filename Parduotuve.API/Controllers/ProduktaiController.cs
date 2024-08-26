using Microsoft.AspNetCore.Mvc;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;

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
        }


        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _produktaiService.GetAllProducts();
            return Ok(allProducts);
        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Produktas produktas)
        {
            try
            {
                await _produktaiService.AddProduct(produktas);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }



        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int produktoId)
        {
            try
            {
                var foundProduct = await _produktaiService.GetProductById(produktoId);
                return Ok(foundProduct);

            }
            catch
            {

                return Problem();

            }

        }

        [HttpPatch("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Produktas produktas)
        {
            try
            {
                await _produktaiService.UpdateProduct(produktas);
                return Ok(produktas);

            }
            catch
            {
                return Problem();
            }

        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProductById(int produktoId)
        {
            await _produktaiService.DeleteProductById(produktoId);
            return Ok();
        }



    }
}
