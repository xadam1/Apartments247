using AutoMapper;
using Infrastructure;
using System;
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

        public async Task<List<T>> GetMonthlyCostsByUnitIdAsync<T>(int id, DateTime fromDate, DateTime toDate)
        {
            var query = _unitOfWork.MonthlyCostsQuery
                .FilterByUnitId(id)
                .FilterByDate(fromDate, toDate);

            var monthlyCosts = await query.ExecuteAsync();
            return _mapper.Map<List<T>>(monthlyCosts);
        }
    }
}
