using Parduotuve.Core.Models;
using Parduotuve.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parduotuve.Core.Contracts
{
    public interface IVartotojaiService
    {
        Task AddBuyer(Pirkejas pirkejas);
        Task AddSeller(Pardavejas pardavejas);


        Task<List<Pirkejas>> GetAllBuyers();
        Task<List<Pardavejas>> GetAllSellers();


        Task UpdateBuyer(Pirkejas pirkejas);
        Task UpdateSeller(Pardavejas pardavejas);


        Task<Pirkejas> GetBuyerById(int pirkejoId);
        Task<Pardavejas> GetSellerById(int pardavejoId);


        Task DeleteSellerById(int pardavejoId);
        Task DeleteBuyerById(int pirkejoId);
    




    }
}
