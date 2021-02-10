using BLL.Services;
using Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public class MonthlyCostFacade : IMonthlyCostFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMonthlyCostService _monthlyCostService;

        public MonthlyCostFacade(IUnitOfWork unitOfWork, IMonthlyCostService monthlyCostService)
        {
            _unitOfWork = unitOfWork;
            _monthlyCostService = monthlyCostService;
        }

        public async Task<List<T>> GetMonthlyCostsByUnitIdAsync<T>(int id)
        {
            return await _monthlyCostService.GetMonthlyCostsByUnitIdAsync<T>(id);
        }
    }
}
