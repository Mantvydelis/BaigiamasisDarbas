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
        public Task AddUser(Vartotojas vartotojas)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserById(int vartotojoId)
        {
            throw new NotImplementedException();
        }

        public Task<Vartotojas> GetUserById(int vartotojoId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(Vartotojas vartotojas)
        {
            throw new NotImplementedException();
        }
    }
}
