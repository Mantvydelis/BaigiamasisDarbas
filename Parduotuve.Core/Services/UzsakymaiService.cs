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
        public Task AddOrder(Uzsakymas uzsakymas)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderById(int uzsakymoId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Uzsakymas>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Uzsakymas> GetOrderById(int uzsakymoId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(Uzsakymas uzsakymas)
        {
            throw new NotImplementedException();
        }
    }
}
