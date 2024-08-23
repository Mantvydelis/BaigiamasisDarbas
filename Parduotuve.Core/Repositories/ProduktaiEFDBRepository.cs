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
    public class ProduktaiEFDBRepository : IProduktaiEFDBRepository
    {
        public async Task AddProduct(Produktas produktas)
        {
            using (var context = new MyDbContext())
            {
                await context.Produktai.AddAsync(produktas);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductById(int produktoId)
        {
            using (var context = new MyDbContext())
            {
                context.Produktai.Remove(await context.Produktai.FindAsync(produktoId));
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Produktas>> GetAllProducts()
        {
            using (var context = new MyDbContext())
            {
                List<Produktas> allProducts = await context.Produktai.ToListAsync();
                return allProducts;
            }
        }

        public async Task<Produktas> GetProductById(int produktoId)
        {
            using (var context = new MyDbContext())
            {
                Produktas foundProduct = context.Produktai.Where(x => x.ProduktoId == produktoId).First();
                return foundProduct;
            }
        }

        public async Task UpdateProduct(Produktas produktas)
        {
            using (var context = new MyDbContext())
            {
                context.Produktai.Update(produktas);
                await context.SaveChangesAsync();
            }
        }
    }
}
