using MongoDB.Driver;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Repositories
{
    public class MongoDbCacheRepository : IMongoDbCacheRepository
    {
        private IMongoCollection<Pardavejas> _pardavejaiCache;
        private IMongoCollection<Pirkejas> _pirkejaiCache;
        private IMongoCollection<Produktas> _produktaiCache;
        private IMongoCollection<Uzsakymas> _uzsakymaiCache;
        private IMongoCollection<Vartotojas> _vartotojaiCache;

        public MongoDbCacheRepository(IMongoClient mongoClient)
        {
            _pardavejaiCache = mongoClient.GetDatabase("pardavejai").GetCollection<Pardavejas>("pardavejai_cache");
            _pirkejaiCache = mongoClient.GetDatabase("pirkejai").GetCollection<Pirkejas>("pirkejai_cache");
            _produktaiCache = mongoClient.GetDatabase("produktai").GetCollection<Produktas>("produktai_cache");
            _uzsakymaiCache = mongoClient.GetDatabase("uzsakymai").GetCollection<Uzsakymas>("uzsakymai_cache");
            _vartotojaiCache = mongoClient.GetDatabase("vartotojai").GetCollection<Vartotojas>("vartotojai_cache");
        }






    }
}
