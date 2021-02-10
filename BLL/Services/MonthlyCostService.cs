using AutoMapper;
using Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MonthlyCostService : IMonthlyCostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MonthlyCostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<T>> GetMonthlyCostsByUnitIdAsync<T>(int id)
        {
            var query = _unitOfWork.MonthlyCostsQuery.FilterByUnitId(id);
            var monthlyCosts = await query.ExecuteAsync();
            return _mapper.Map<List<T>>(monthlyCosts);
        }
    }
}
