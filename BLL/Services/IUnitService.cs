﻿using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUnitService
    {
        Task<T[]> GetUnitsByGroupIdAsync<T>(int id);

        //Task<T[]> GetUnitGroupNamesByUserId<T>(int id);
    }
}
