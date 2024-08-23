using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Contracts
{
    public interface IUzsakymaiEFDBRepository
    {
        Task AddOrder(Uzsakymas uzsakymas);
        Task UpdateOrder(Uzsakymas uzsakymas);

        Task<List<Uzsakymas>> GetAllOrders();

        Task<Uzsakymas> GetOrderById(int uzsakymoId);

        Task DeleteOrderById(int uzsakymoId);



    }
}
