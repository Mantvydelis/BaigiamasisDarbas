using Microsoft.AspNetCore.Mvc;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using Serilog;

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
            Log.Information("VartotojaiController started");
        }


        [HttpGet("GetAllBuyers")]
        public async Task<IActionResult> Index()
        {
            Log.Information("GetAllBuyers service started");
            var allBuyers = await _vartotojaiService.GetAllBuyers();
            Log.Information("GetAllBuyers worked and shows all buyers:{@AllBuyers}", allBuyers);
            return Ok(allBuyers);
        }

        [HttpGet("GetAllSellers")]
        public async Task<IActionResult> GetAllSellers()
        {
            Log.Information("GetAllSellers service started");
            var allSellers = await _vartotojaiService.GetAllSellers();
            Log.Information("GetAllSellers worked and shows all sellers:{@AllSellers}", allSellers);
            return Ok(allSellers);
        }



        [HttpPost("AddBuyer")]
        public async Task<IActionResult> AddBuyer(Pirkejas pirkejas)
        {
            Log.Information("AddBuyer service started");
            try
            {
                await _vartotojaiService.AddBuyer(pirkejas);
                Log.Information("Buyer added successfully: {@Pirkejas}", pirkejas);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Buyer was not added");
                return Problem();
            }


        }

        [HttpPost("AddSeller")]
        public async Task<IActionResult> AddSeller(Pardavejas pardavejas)
        {
            Log.Information("AddSeller service started");
            try
            {
                await _vartotojaiService.AddSeller(pardavejas);
                Log.Information("Buyer added successfully: {@Pardavejas}", pardavejas);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Seller was not added");
                return Problem();
            }


        }

        [HttpGet("GetSellerById")]
        public async Task<IActionResult> GetSellerById(int pardavejoId)
        {
            Log.Information("GetSellerById service started");
            try
            {
                var foundSeller = await _vartotojaiService.GetSellerById(pardavejoId);
                Log.Information("Seller found successfully: {@FoundSeller}", foundSeller);
                return Ok(foundSeller);

            }
            catch
            {
                Log.Error("Seller was not found");
                return Problem();

            }

        }

        [HttpGet("GetBuyerById")]
        public async Task<IActionResult> GetBuyerById(int pirkejoId)
        {
            Log.Information("GetBuyerById service started");
            try
            {
                var foundBuyer = await _vartotojaiService.GetBuyerById(pirkejoId);
                Log.Information("Buyer found successfully: {@FoundBuyer}", foundBuyer);
                return Ok(foundBuyer);

            }
            catch
            {
                Log.Error("Buyer was not found");
                return Problem();

            }

        }

        [HttpPatch("UpdateSeller")]
        public async Task<IActionResult> UpdateSeller(Pardavejas pardavejas)
        {
            Log.Information("UpdateSeller service started");
            try
            {
                await _vartotojaiService.UpdateSeller(pardavejas);
                Log.Information("Seller updated successfully:{@Pardavejas}", pardavejas);
                return Ok(pardavejas);

            }
            catch
            {
                Log.Error("There was a problem with updating");
                return Problem();
            }

        }



        [HttpPatch("UpdateBuyer")]
        public async Task<IActionResult> UpdateBuyer(Pirkejas pirkejas)
        {
            Log.Information("UpdateBuyer service started");
            try
            {
                await _vartotojaiService.UpdateBuyer(pirkejas);
                Log.Information("Buyer updated successfully:{@Pirkejas}", pirkejas);
                return Ok(pirkejas);

            }
            catch
            {
                Log.Error("There was a problem with updating");
                return Problem();
            }

        }


        [HttpDelete("DeleteSeller")]
        public async Task<IActionResult> DeleteSellerById(int pardavejoId)
        {
            Log.Information("DeleteSeller service started");
            await _vartotojaiService.DeleteSellerById(pardavejoId);
            Log.Information("Seller deleted successfully");
            return Ok();
        }

        [HttpDelete("DeleteBuyer")]
        public async Task<IActionResult> DeleteBuyerById(int pirkejoId)
        {
            Log.Information("DeleteBuyer service started");
            await _vartotojaiService.DeleteBuyerById(pirkejoId);
            Log.Information("Buyer deleted successfully");
            return Ok();
        }
    }
}
