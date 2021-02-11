using BLL.Services;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public class CostFacade : ICostFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICostService _costService;

        public CostFacade(IUnitOfWork unitOfWork, ICostService costService)
        {
            _unitOfWork = unitOfWork;
            _costService = costService;
        }

        public async Task CreateCostAsync<T>(T costDTO)
        {
            _costService.CreateCost<T>(costDTO);

            await _unitOfWork.CommitAsync();
        }

        public async Task<List<T>> GetCostsByUnitIdAsync<T>(int id, DateTime fromDate, DateTime toDate)
        {
            return await _costService.GetCostsByUnitIdAsync<T>(id, fromDate, toDate);
        }
    }
}
