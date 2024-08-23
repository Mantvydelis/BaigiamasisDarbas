﻿using Parduotuve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Contracts
{
    public interface IVartotojaiEFDBRepository
    {
        Task AddUser(Vartotojas vartotojas);
        Task UpdateUser(Vartotojas vartotojas);

        Task<Vartotojas> GetUserById(int vartotojoId);

        Task DeleteUserById(int vartotojoId);


    }
}