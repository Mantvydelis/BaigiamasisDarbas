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
        public ProduktaiService(IProduktaiEFDBRepository produktaiRepository, IMongoDbCacheRepository mongoDbCache)
        {
            _produktaiRepository = produktaiRepository;
            _mongoCache = mongoDbCache;
        }

        public Task AddProduct(Produktas produktas)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductById(int produktoId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produktas>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Produktas> GetProductById(int produktoId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Produktas produktas)
        {
            throw new NotImplementedException();
        }
    }
}
