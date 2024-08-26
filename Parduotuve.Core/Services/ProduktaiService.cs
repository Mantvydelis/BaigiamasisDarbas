using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Services
{
    public class ProduktaiService : IProduktaiService
    {

        private readonly IProduktaiEFDBRepository _produktaiRepository;
        private readonly IMongoDbCacheRepository _mongoCache;
        private List<Produktas> allProducts = new List<Produktas>();
        public ProduktaiService(IProduktaiEFDBRepository produktaiRepository, IMongoDbCacheRepository mongoDbCache)
        {
            _produktaiRepository = produktaiRepository;
            _mongoCache = mongoDbCache;
        }

        public async Task AddProduct(Produktas produktas)
        {
            await _produktaiRepository.AddProduct(produktas);
            await _mongoCache.AddProduct(produktas);
        }

        public async Task DeleteProductById(int produktoId)
        {
            await _produktaiRepository.DeleteProductById(produktoId);
            await _mongoCache.DeleteProductById(produktoId);
        }

        public async Task<List<Produktas>> GetAllProducts()
        {
            List<Produktas> results;

            if ((results = _mongoCache.GetAllProducts().Result) != null && results.Any())
                return results;

            results = await _produktaiRepository.GetAllProducts();

            if (results != null && results.Any())
            {
                foreach (var produktas in results)
                {
                    await _mongoCache.AddProduct(produktas);
                }
            }
            return results;
        }

        public async Task<Produktas> GetProductById(int produktoId)
        {
            Produktas foundProduct = await _produktaiRepository.GetProductById(produktoId);
            return foundProduct; 
        }

        public async Task UpdateProduct(Produktas produktas)
        {
            await _produktaiRepository.UpdateProduct(produktas);
            await _mongoCache.UpdateProduct(produktas);
        }
    }
}
