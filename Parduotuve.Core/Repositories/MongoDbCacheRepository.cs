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

        public async Task DeleteCache()
        {
            var deleteSellers = _pardavejaiCache.Database.DropCollectionAsync("pardavejai_cache");
            var deleteBuyers = _pirkejaiCache.Database.DropCollectionAsync("pirkejai_cache");
            //uzduotyje neparasyta istrinti produktus
            var deleteOrders = _uzsakymaiCache.Database.DropCollectionAsync("uzsakymai_cache");
            var deleteUsers = _vartotojaiCache.Database.DropCollectionAsync("vartotojai_cache");

            await Task.WhenAll(deleteSellers, deleteBuyers, deleteOrders, deleteUsers);
        }


        public async Task AddSeller(Pardavejas pardavejas)
        {
            await _pardavejaiCache.InsertOneAsync(pardavejas);
        }

        public async Task AddBuyer(Pirkejas pirkejas)
        {
            await _pirkejaiCache.InsertOneAsync(pirkejas);
        }

        public async Task AddProduct(Produktas produktas)
        {
            await _produktaiCache.InsertOneAsync(produktas);
        }

        public async Task AddOrder(Uzsakymas uzsakymas)
        {
            await _uzsakymaiCache.InsertOneAsync(uzsakymas);
        }

        public async Task AddUser(Vartotojas vartotojas)
        {
            await _vartotojaiCache.InsertOneAsync(vartotojas);
        }

        public async Task<Pardavejas> GetSellerById(int pardavejoId)
        {
            try
            {
                return (await _pardavejaiCache.FindAsync<Pardavejas>(x => x.PardavejoId == pardavejoId)).First();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Pirkejas> GetBuyerById(int pirkejoId)
        {
            try
            {
                return (await _pirkejaiCache.FindAsync<Pirkejas>(x => x.PirkejoId == pirkejoId)).First();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Produktas> GetProductById(int produktoId)
        {
            try
            {
                return (await _produktaiCache.FindAsync<Produktas>(x => x.ProduktoId == produktoId)).First();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Uzsakymas> GetOrderById(int uzsakymoId)
        {
            try
            {
                return (await _uzsakymaiCache.FindAsync<Uzsakymas>(x => x.UzsakymoId == uzsakymoId)).First();
            }
            catch
            {
                return null;
            }
        }


        public async Task<List<Pirkejas>> GetAllBuyers()
        {
            try
            {
                var allPirkejai = await _pirkejaiCache.FindAsync<Pirkejas>(_ => true);
                return await allPirkejai.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Pardavejas>> GetAllSellers()
        {
            try
            {
                var allPardavejai = await _pardavejaiCache.FindAsync<Pardavejas>(_ => true);
                return await allPardavejai.ToListAsync();
            }
            catch
            {
                return null;
            }
        }



        public async Task<List<Produktas>> GetAllProducts()
        {
            try
            {
                var allProducts = await _produktaiCache.FindAsync<Produktas>(_ => true);
                return await allProducts.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Uzsakymas>> GetAllOrders()
        {
            try
            {
                var allOrders = await _uzsakymaiCache.FindAsync<Uzsakymas>(_ => true);
                return await allOrders.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task UpdateProduct(Produktas produktas)
        {
            var filter = Builders<Produktas>.Filter.Eq(p => p.ProduktoId, produktas.ProduktoId);
            var update = Builders<Produktas>.Update
                .Set(p => p.Pavadinimas, produktas.Pavadinimas)
                .Set(p => p.Kaina, produktas.Kaina)
                .Set(p => p.Kategorija, produktas.Kategorija)
                .Set(p => p.KiekisSandelyje, produktas.KiekisSandelyje);

            var result = await _produktaiCache.UpdateOneAsync(filter, update);

            if (result.MatchedCount == 0)
            {
                await _produktaiCache.InsertOneAsync(produktas);
            }
        }

        public async Task UpdateOrder(Uzsakymas uzsakymas)
        {
            var filter = Builders<Uzsakymas>.Filter.Eq(p => p.UzsakymoId, uzsakymas.UzsakymoId);
            var update = Builders<Uzsakymas>.Update
                .Set(p => p.PardavejoId, uzsakymas.PardavejoId)
                .Set(p => p.PirkejoId, uzsakymas.PirkejoId)
                .Set(p => p.ProduktoId, uzsakymas.ProduktoId)
                .Set(p => p.UzsakymoData, uzsakymas.UzsakymoData)
                .Set(p => p.Kiekis, uzsakymas.Kiekis);

            var result = await _uzsakymaiCache.UpdateOneAsync(filter, update);

            if (result.MatchedCount == 0)
            {
                await _uzsakymaiCache.InsertOneAsync(uzsakymas);
            }
        }

        public async Task UpdateBuyer(Pirkejas pirkejas)
        {
            var filter = Builders<Pirkejas>.Filter.Eq(p => p.PirkejoId, pirkejas.PirkejoId);
            var update = Builders<Pirkejas>.Update
                .Set(p => p.Vardas, pirkejas.Vardas)
                .Set(p => p.Pavarde, pirkejas.Pavarde)
                .Set(p => p.ElPastas, pirkejas.ElPastas)
                .Set(p => p.TelNumeris, pirkejas.TelNumeris);


            var result = await _pirkejaiCache.UpdateOneAsync(filter, update);

            if (result.MatchedCount == 0)
            {
                await _pirkejaiCache.InsertOneAsync(pirkejas);
            }
        }

        public async Task UpdateSeller(Pardavejas pardavejas)
        {
            var filter = Builders<Pardavejas>.Filter.Eq(p => p.PardavejoId, pardavejas.PardavejoId);
            var update = Builders<Pardavejas>.Update
                .Set(p => p.Vardas, pardavejas.Vardas)
                .Set(p => p.Pavarde, pardavejas.Pavarde)
                .Set(p => p.ElPastas, pardavejas.ElPastas)
                .Set(p => p.TelNumeris, pardavejas.TelNumeris);


            var result = await _pardavejaiCache.UpdateOneAsync(filter, update);

            if (result.MatchedCount == 0)
            {
                await _pardavejaiCache.InsertOneAsync(pardavejas);
            }
        }

        public async Task DeleteOrderById(int uzsakymoId)
        {
            await _uzsakymaiCache.DeleteOneAsync<Uzsakymas>(x => x.UzsakymoId == uzsakymoId);
        }

        public async Task DeleteSellerById(int pardavejoId)
        {
            await _pardavejaiCache.DeleteOneAsync<Pardavejas>(x => x.PardavejoId == pardavejoId);
        }

        public async Task DeleteBuyerById(int pirkejoId)
        {
            await _pirkejaiCache.DeleteOneAsync<Pirkejas>(x => x.PirkejoId == pirkejoId);
        }

        public async Task DeleteProductById(int produktoId)
        {
            await _produktaiCache.DeleteOneAsync<Produktas>(x => x.ProduktoId == produktoId);
        }
    }
}
