using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Services
{
    public class UzsakymaiService : IUzsakymaiService
    {

        private readonly IUzsakymaiEFDBRepository _uzsakymaiRepository;
        private readonly IMongoDbCacheRepository _mongoCache;
        public UzsakymaiService(IUzsakymaiEFDBRepository uzsakymaiRepository, IMongoDbCacheRepository mongoDbCache)
        {
            _uzsakymaiRepository = uzsakymaiRepository;
            _mongoCache = mongoDbCache;
        }



        public async Task AddOrder(Uzsakymas uzsakymas)
        {
            await _uzsakymaiRepository.AddOrder(uzsakymas);
            await _mongoCache.AddOrder(uzsakymas);
        }

        public async Task DeleteOrderById(int uzsakymoId)
        {
            await _uzsakymaiRepository.DeleteOrderById(uzsakymoId);
            await _mongoCache.DeleteOrderById(uzsakymoId);
        }

        public async Task<List<Uzsakymas>> GetAllOrders()
        {
            List<Uzsakymas> results;

            if ((results = _mongoCache.GetAllOrders().Result) != null && results.Any())
                return results;

            results = await _uzsakymaiRepository.GetAllOrders();

            if (results != null && results.Any())
            {
                foreach (var uzsakymas in results)
                {
                    await _mongoCache.AddOrder(uzsakymas);
                }
            }
            return results;
        }

        public async Task<Uzsakymas> GetOrderById(int uzsakymoId)
        {
            Uzsakymas foundOrder = await _uzsakymaiRepository.GetOrderById(uzsakymoId);
            return foundOrder;
        }

        public async Task UpdateOrder(Uzsakymas uzsakymas)
        {
            await _uzsakymaiRepository.UpdateOrder(uzsakymas);
            await _mongoCache.UpdateOrder(uzsakymas);
        }
    }
}
