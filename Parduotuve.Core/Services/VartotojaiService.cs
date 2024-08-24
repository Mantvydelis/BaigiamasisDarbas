using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
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


        public async Task AddUser(Vartotojas vartotojas)
        {
            if (vartotojas is Pirkejas pirkejas)
            {
                await _mongoCache.AddBuyer(pirkejas);
                await _vartotojaiRepository.AddBuyer(pirkejas);
            }
            else if (vartotojas is Pardavejas pardavejas)
            {
                await _vartotojaiRepository.AddSeller(pardavejas);
                await _mongoCache.AddSeller(pardavejas);
            }
           
        }

        public async Task DeleteUserById(int vartotojoId, bool yraPirkejas)
        {
            if (yraPirkejas)
            {
                await _mongoCache.DeleteBuyerById(vartotojoId);
                await _vartotojaiRepository.DeleteBuyerById(vartotojoId);
            }
            else
            {
                await _mongoCache.DeleteSellerById(vartotojoId);
                await _vartotojaiRepository.DeleteSellerById(vartotojoId);
            }
        }

        public async Task<Vartotojas> GetUserById(int vartotojoId, bool yraPirkejas)
        {
            if (yraPirkejas)
            {
                return await _vartotojaiRepository.GetBuyerById(vartotojoId);
            }
            else
            {
                return await _vartotojaiRepository.GetSellerById(vartotojoId);
            }
        }

        public async Task UpdateUser(Vartotojas vartotojas)
        {
            if (vartotojas is Pirkejas pirkejas)
            {
                await _mongoCache.UpdateBuyer(pirkejas);
                await _vartotojaiRepository.UpdateBuyer(pirkejas);
            }
            else if (vartotojas is Pardavejas pardavejas)
            {
                await _vartotojaiRepository.UpdateSeller(pardavejas);
                await _mongoCache.UpdateSeller(pardavejas);
            }
        }
    }
}
