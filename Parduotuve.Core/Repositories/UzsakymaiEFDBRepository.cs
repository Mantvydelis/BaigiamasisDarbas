using Microsoft.EntityFrameworkCore;
using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Repositories
{
    public class UzsakymaiEFDBRepository : IUzsakymaiEFDBRepository
    {
        public async Task AddOrder(Uzsakymas uzsakymas)
        {
            using (var context = new MyDbContext())
            {
                await context.Uzsakymai.AddAsync(uzsakymas);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderById(int uzsakymoId)
        {
            using (var context = new MyDbContext())
            {
                context.Uzsakymai.Remove(await context.Uzsakymai.FindAsync(uzsakymoId));
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Uzsakymas>> GetAllOrders()
        {
            using (var context = new MyDbContext())
            {
                List<Uzsakymas> allOrders = await context.Uzsakymai.ToListAsync();
                return allOrders;
            }
        }

        public async Task<Uzsakymas> GetOrderById(int uzsakymoId)
        {
            using (var context = new MyDbContext())
            {
                Uzsakymas foundOrder = context.Uzsakymai.Where(x => x.UzsakymoId == uzsakymoId).First();
                return foundOrder;
            }
        }

        public async Task UpdateOrder(Uzsakymas uzsakymas)
        {
            using (var context = new MyDbContext())
            {
                context.Uzsakymai.Update(uzsakymas);
                await context.SaveChangesAsync();
            }
        }
    }
}
