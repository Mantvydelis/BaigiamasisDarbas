using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Repositories
{
    public class VartotojaiEFDBRepository : IVartotojaiEFDBRepository
    {
        public async Task AddBuyer(Pirkejas pirkejas)
        {
            using (var context = new MyDbContext())
            {
                await context.Pirkejai.AddAsync(pirkejas);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddSeller(Pardavejas pardavejas)
        {
            using (var context = new MyDbContext())
            {
                await context.Pardavejai.AddAsync(pardavejas);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteSellerById(int pardavejoId)
        {
            using (var context = new MyDbContext())
            {
                context.Pardavejai.Remove(await context.Pardavejai.FindAsync(pardavejoId));
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteBuyerById(int pirkejoId)
        {
            using (var context = new MyDbContext())
            {
                context.Pirkejai.Remove(await context.Pirkejai.FindAsync(pirkejoId));
                await context.SaveChangesAsync();
            }
        }


        public async Task<Pardavejas> GetSellerById(int pardavejoId)
        {
            using (var context = new MyDbContext())
            {
                Pardavejas foundSeller = context.Pardavejai.Where(x => x.PardavejoId == pardavejoId).First();
                return foundSeller;
            }
        }

        public async Task<Pirkejas> GetBuyerById(int pirkejoId)
        {
            using (var context = new MyDbContext())
            {
                Pirkejas foundBuyer = context.Pirkejai.Where(x => x.PirkejoId == pirkejoId).First();
                return foundBuyer;
            }
        }

        public async Task UpdateBuyer(Pirkejas pirkejas)
        {
            using (var context = new MyDbContext())
            {
                context.Pirkejai.Update(pirkejas);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateSeller(Pardavejas pardavejas)
        {
            using (var context = new MyDbContext())
            {
                context.Pardavejai.Update(pardavejas);
                await context.SaveChangesAsync();
            }
        }

    }
}
