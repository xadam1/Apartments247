using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using Infrastructure;
using Infrastructure.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UnitGroupService : IUnitGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitGroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<T> GetUnitGroupByIdAsync<T>(int id)
        {
            var unitGroup = await _unitOfWork.UnitGroupRepository.GetByIdAsync(id);

            return _mapper.Map<T>(unitGroup);
        }

        public async Task<List<T>> GetUnitGroupNamesByUserIdAsync<T>(int id)
        {
            var query = _unitOfWork.UnitGroupsWithUsersWithSpecificationsQuery.FilterByUserId(id);
            var unitGroups = await query.ExecuteAsync();
            return _mapper.Map<List<T>>(unitGroups);
        }

        public async Task<List<T>> GetUnitGroupsByUserIdAsync<T>(int id)
        {
            var query = _unitOfWork.UnitGroupsWithUsersQuery.FilterByUserId(id);
            var unitGroups = await query.ExecuteAsync();
            return _mapper.Map<List<T>>(unitGroups);
        }

        public void CreateUnitGroup(UnitGroupDTO unitGroupDTO)
        {
            _unitOfWork.UnitGroupRepository.Add(_mapper.Map<UnitGroup>(unitGroupDTO));
        }

        public async Task UpdateUnitGroupAsync(int id, UnitGroupDTO unitGroupDTO)
        {
            var unitGroup = await _unitOfWork.UnitGroupRepository.GetByIdAsync(id);
            unitGroup.Specification = unitGroupDTO.Specification;

            _unitOfWork.UnitGroupRepository.Update(unitGroup);
        }
    }
}
