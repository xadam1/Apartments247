using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<T> GetUnitByIdAsync<T>(int id)
        {
            var unitGroup = await _unitOfWork.UnitRepository.GetByIdAsync(id);

            return _mapper.Map<T>(unitGroup);
        }

        public async Task<List<T>> GetUnitsByGroupIdAsync<T>(int id)
        {
            var query = _unitOfWork.UnitsWithUnitGroupsQuery.FilterByUnitGroupId(id);
            var units = await query.ExecuteAsync();
            return _mapper.Map<List<T>>(units);
        }

        public void CreateUnit(UnitDTO unitDTO)
        {
            _unitOfWork.UnitRepository.Add(_mapper.Map<Unit>(unitDTO));
        }

        public async Task UpdateUnitAsync(int id, UnitDTO unitDTO)
        {
            var unit = await _unitOfWork.UnitRepository.GetByIdAsync(id);
            unit.UnitTypeId = unitDTO.UnitTypeId;
            unit.UnitGroupId = unitDTO.UnitGroupId;
            unit.CurrentCapacity = unitDTO.CurrentCapacity;
            unit.MaxCapacity = unitDTO.MaxCapacity;
            unit.Contract = unitDTO.Contract;
            unit.MonthlyIncome = unitDTO.MonthlyIncome;

            _unitOfWork.UnitRepository.Update(unit);
        }
    }
}
