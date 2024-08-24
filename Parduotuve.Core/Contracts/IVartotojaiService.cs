using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parduotuve.Core.Contracts
{
    public interface IVartotojaiService
    {
        Task AddUser(Vartotojas vartotojas);
        Task UpdateUser(Vartotojas vartotojas);

        Task<Vartotojas> GetUserById(int vartotojoId, bool yraPirkejas);

        Task DeleteUserById(int vartotojoId, bool yraPirkejas);



    }
}
