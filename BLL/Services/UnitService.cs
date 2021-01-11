using AutoMapper;
using Infrastructure;
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

        public async Task<T[]> GetUnitsByGroupIdAsync<T>(int id)
        {
            var query = _unitOfWork.UnitsWithUnitGroupsQuery.FilterByUnitGroupId(id);
            var units = await query.ExecuteAsync();
            return _mapper.Map<T[]>(units);
        }
    }
}
