using Parduotuve.Core.Contracts;
using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Services
{
    public class VartotojaiService : IVartotojaiService
    {

        private readonly IVartotojaiEFDBRepository _vartotojaiRepository;
        private readonly IMongoDbCacheRepository _mongoCache;
        public VartotojaiService(IVartotojaiEFDBRepository vartotojaiRepository, IMongoDbCacheRepository mongoDbCache)
        {
            _vartotojaiRepository = vartotojaiRepository;
            _mongoCache = mongoDbCache;
        }


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
