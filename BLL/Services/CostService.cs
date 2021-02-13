using AutoMapper;
using BLL.DTOs;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Services
{
    public class CostService : ICostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<T>> GetCostsByUnitIdAsync<T>(int id, DateTime fromDate, DateTime toDate)
        {
            var query = _unitOfWork.CostQuery
                .FilterByUnitId(id)
                .FilterByDate(fromDate, toDate);

            var monthlyCosts = await query.ExecuteAsync();
            return _mapper.Map<List<T>>(monthlyCosts);
        }

        public void CreateCost<T>(T costDTO)
        {
            _unitOfWork.CostRepository.Add(_mapper.Map<Cost>(costDTO));
        }

        public async Task UpdateCostAsync(int id, CostDTO costDTO)
        {
            var cost = await _unitOfWork.CostRepository.GetByIdAsync(id);
            cost.CostType = costDTO.CostType;
            cost.Date = costDTO.Date;
            cost.Name = costDTO.Name;
            cost.Price = costDTO.Price;
            cost.UnitId = costDTO.UnitId;

            _unitOfWork.CostRepository.Update(cost);
        }

        public void DeleteCost(int id)
        {
            var costTask = _unitOfWork.CostRepository.GetByIdAsync(id);
            costTask.Wait();

            var cost = costTask.Result;
            _unitOfWork.CostRepository.Delete(cost);
        }
    }
}
