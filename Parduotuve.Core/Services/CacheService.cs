using Parduotuve.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMongoDbCacheRepository _mongoCache;

        public CacheService(IMongoDbCacheRepository mongoDbCache)
        {
            _mongoCache = mongoDbCache;
        }
        public async Task DeleteCaches()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromMinutes(5));
                var erase = _mongoCache.DeleteCache();

                await Task.WhenAll(erase);
                Console.WriteLine("Duombazes istrintos");

            }

        }
    }
}
