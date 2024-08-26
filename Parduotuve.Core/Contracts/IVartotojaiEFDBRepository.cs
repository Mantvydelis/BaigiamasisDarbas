using Microsoft.EntityFrameworkCore;
using Parduotuve.Core.Models;
using Parduotuve.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Contracts
{
    public interface IVartotojaiEFDBRepository
    {
         Task AddBuyer(Pirkejas pirkejas);

         Task AddSeller(Pardavejas pardavejas);

         Task DeleteSellerById(int pardavejoId);

         Task DeleteBuyerById(int pirkejoId);

         Task<Pardavejas> GetSellerById(int pardavejoId);

         Task<Pirkejas> GetBuyerById(int pirkejoId);

         Task UpdateBuyer(Pirkejas pirkejas);

         Task UpdateSeller(Pardavejas pardavejas);

         Task<List<Pardavejas>> GetAllSellers();

         Task<List<Pirkejas>> GetAllBuyers();



    }
}
