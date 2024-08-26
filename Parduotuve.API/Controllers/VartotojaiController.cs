using Microsoft.AspNetCore.Mvc;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;

namespace Parduotuve.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VartotojaiController : Controller
    {

        private readonly IVartotojaiService _vartotojaiService;

        public VartotojaiController(IVartotojaiService vartotojaiService)
        {
            _vartotojaiService = vartotojaiService;
        }


        [HttpGet("GetAllBuyers")]
        public async Task<IActionResult> Index()
        {
            var allBuyers = await _vartotojaiService.GetAllBuyers();
            return Ok(allBuyers);
        }

        [HttpGet("GetAllSellers")]
        public async Task<IActionResult> GetAllSellers()
        {
            var allSellers = await _vartotojaiService.GetAllSellers();
            return Ok(allSellers);
        }



        [HttpPost("AddBuyer")]
        public async Task<IActionResult> AddBuyer(Pirkejas pirkejas)
        {
            try
            {
                await _vartotojaiService.AddBuyer(pirkejas);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem();
            }


        }

        [HttpPost("AddSeller")]
        public async Task<IActionResult> AddSeller(Pardavejas pardavejas)
        {
            try
            {
                await _vartotojaiService.AddSeller(pardavejas);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem();
            }


        }

        [HttpGet("GetSellerById")]
        public async Task<IActionResult> GetSellerById(int pardavejoId)
        {
            try
            {
                var foundSeller = await _vartotojaiService.GetSellerById(pardavejoId);
                return Ok(foundSeller);

            }
            catch
            {

                return Problem();

            }

        }

        [HttpGet("GetBuyerById")]
        public async Task<IActionResult> GetBuyerById(int pirkejoId)
        {
            try
            {
                var foundBuyer = await _vartotojaiService.GetBuyerById(pirkejoId);
                return Ok(foundBuyer);

            }
            catch
            {

                return Problem();

            }

        }

        [HttpPatch("UpdateSeller")]
        public async Task<IActionResult> UpdateSeller(Pardavejas pardavejas)
        {
            try
            {
                await _vartotojaiService.UpdateSeller(pardavejas);
                return Ok(pardavejas);

            }
            catch
            {
                return Problem();
            }

        }



        [HttpPatch("UpdateBuyer")]
        public async Task<IActionResult> UpdateBuyer(Pirkejas pirkejas)
        {
            try
            {
                await _vartotojaiService.UpdateBuyer(pirkejas);
                return Ok(pirkejas);

            }
            catch
            {
                return Problem();
            }

        }


        [HttpDelete("DeleteSeller")]
        public async Task<IActionResult> DeleteSellerById(int pardavejoId)
        {
            await _vartotojaiService.DeleteSellerById(pardavejoId);
            return Ok();
        }

        [HttpDelete("DeleteBuyer")]
        public async Task<IActionResult> DeleteBuyerById(int pirkejoId)
        {
            await _vartotojaiService.DeleteBuyerById(pirkejoId);
            return Ok();
        }
    }
}
