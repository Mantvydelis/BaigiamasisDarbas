using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using Parduotuve.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Services
{
    public class VartotojaiService : IVartotojaiService
    {

        private readonly IVartotojaiEFDBRepository _vartotojaiRepository;
        private readonly IMongoDbCacheRepository _mongoCache;
        public VartotojaiService(IVartotojaiEFDBRepository vartotojaiRepository, IMongoDbCacheRepository mongoDbCache)
        {
            _vartotojaiRepository = vartotojaiRepository;
            _mongoCache = mongoDbCache;
        }


        public async Task AddBuyer(Pirkejas pirkejas)
        {
            using (var context = new MyDbContext())
            {
                await _mongoCache.AddBuyer(pirkejas);
                await _vartotojaiRepository.AddBuyer(pirkejas);
            }
        }

        public async Task AddSeller(Pardavejas pardavejas)
        {
            using (var context = new MyDbContext())
            {
                await _vartotojaiRepository.AddSeller(pardavejas);
                await _mongoCache.AddSeller(pardavejas);
            }
        }

        public async Task<List<Pirkejas>> GetAllBuyers()
        {
            List<Pirkejas> results;

            if ((results = _mongoCache.GetAllBuyers().Result) != null && results.Any())
                return results;

            results = await _vartotojaiRepository.GetAllBuyers();

            if (results != null && results.Any())
            {
                foreach (var pirkejas in results)
                {
                    await _mongoCache.AddBuyer(pirkejas);
                }
            }
            return results;
        }

        public async Task<List<Pardavejas>> GetAllSellers()
        {
            List<Pardavejas> results;

            if ((results = _mongoCache.GetAllSellers().Result) != null && results.Any())
                return results;

            results = await _vartotojaiRepository.GetAllSellers();

            if (results != null && results.Any())
            {
                foreach (var pardavejas in results)
                {
                    await _mongoCache.AddSeller(pardavejas);
                }
            }
            return results;
        }


        public async Task UpdateBuyer(Pirkejas pirkejas)
        {
            await _mongoCache.UpdateBuyer(pirkejas);
            await _vartotojaiRepository.UpdateBuyer(pirkejas);
        }

        public async Task UpdateSeller(Pardavejas pardavejas)
        {
            await _vartotojaiRepository.UpdateSeller(pardavejas);
            await _mongoCache.UpdateSeller(pardavejas);
        }

        public async Task<Pirkejas> GetBuyerById(int pirkejoId)
        {

          return await _vartotojaiRepository.GetBuyerById(pirkejoId);

        }

        public async Task<Pardavejas> GetSellerById(int pardavejoId)
        {

            return await _vartotojaiRepository.GetSellerById(pardavejoId);

        }

        public async Task DeleteSellerById(int pardavejoId)
        {
            await _mongoCache.DeleteSellerById(pardavejoId);
            await _vartotojaiRepository.DeleteSellerById(pardavejoId);

        }

        public async Task DeleteBuyerById(int pirkejoId)
        {
            await _mongoCache.DeleteBuyerById(pirkejoId);
            await _vartotojaiRepository.DeleteBuyerById(pirkejoId);

        }


        
    }
}
