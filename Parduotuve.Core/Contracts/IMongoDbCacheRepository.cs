using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Contracts
{
    public interface IMongoDbCacheRepository
    {
        Task DeleteCache();

        Task AddSeller(Pardavejas pardavejas);
        Task AddBuyer(Pirkejas pirkejas);
        Task AddProduct(Produktas produktas);
        Task AddOrder(Uzsakymas uzsakymas);
        Task AddUser(Vartotojas vartotojas);


        Task<Pardavejas> GetSellerById(int id);
        Task<Pirkejas> GetBuyerById(int pirkejoId);
        Task<Produktas> GetProductById(int produktoId);
        Task<Uzsakymas> GetOrderById(int uzsakymoId);


        Task<List<Produktas>> GetAllProducts();
        Task<List<Uzsakymas>> GetAllOrders();



        Task UpdateProduct(Produktas produktas);
        Task UpdateOrder(Uzsakymas uzsakymas);
        Task UpdateBuyer(Pirkejas pirkejas);
        Task UpdateSeller(Pardavejas pardavejas);



        Task DeleteOrderById(int uzsakymoId);
        Task DeleteSellerById(int pardavejoId);
        Task DeleteBuyerById(int pirkejoId);
        Task DeleteProductById(int produktoId);








    }
}
