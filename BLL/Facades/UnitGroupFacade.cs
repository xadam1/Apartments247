﻿using System.Collections.Generic;
using BLL.DTOs;
using BLL.Services;
using Infrastructure;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public class UnitGroupFacade : IUnitGroupFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitGroupService _unitGroupService;

        public UnitGroupFacade(IUnitOfWork unitOfWork, IUnitGroupService unitGroupService)
        {
            _unitOfWork = unitOfWork;
            _unitGroupService = unitGroupService;
        }

        public async Task CreateUnitGroupAsync(UnitGroupDTO unitGroupDTO)
        {
            _unitGroupService.CreateUnitGroup(unitGroupDTO);

            await _unitOfWork.CommitAsync();
        }

        public async Task<T> GetUnitGroupByIdAsync<T>(int id)
        {
            return await _unitGroupService.GetUnitGroupByIdAsync<T>(id);
        }

        public async Task<List<T>> GetUnitGroupNamesByUserId<T>(int id)
        {
            return await _unitGroupService.GetUnitGroupNamesByUserIdAsync<T>(id);
        }

        public async Task<List<T>> GetUnitGroupsByUserIdAsync<T>(int id)
        {
            return await _unitGroupService.GetUnitGroupsByUserIdAsync<T>(id);
        }

        public async Task UpdateUnitGroupAsync(int id, UnitGroupDTO unitGroupDTO)
        {
            await _unitGroupService.UpdateUnitGroupAsync(id, unitGroupDTO);

            await _unitOfWork.CommitAsync();
        }

        /*public Task<Dictionary<UnitGroupNameDto, List<UnitNameDto>>> GetAllUsersUnitGroupsWithUnits()
        {
            return new Dictionary<UnitGroupNameDto, List<UnitNameDto>>;
        }*/
    }
}
