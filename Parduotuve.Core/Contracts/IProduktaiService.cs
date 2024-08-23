using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Contracts
{
    public interface IProduktaiService
    {
        Task AddProduct(Produktas produktas);
        Task UpdateProduct(Produktas produktas);

        Task<List<Produktas>> GetAllProducts();

        Task<Produktas> GetProductById(int produktoId);

        Task DeleteProductById(int produktoId);

    }
}
