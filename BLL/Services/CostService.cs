using AutoMapper;
using DAL.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}
