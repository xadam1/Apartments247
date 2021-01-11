using BLL.Services;
using Infrastructure;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public class UnitFacade : IUnitFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitService _unitService;

        public UnitFacade(IUnitOfWork unitOfWork, IUnitService unitService)
        {
            _unitOfWork = unitOfWork;
            _unitService = unitService;
        }

        public async Task<T> GetUnitByIdAsync<T>(int id)
        {
            return await _unitService.GetUnitByIdAsync<T>(id);
        }

        public async Task<T[]> GetUnitsByGroupIdAsync<T>(int id)
        {
            return await _unitService.GetUnitsByGroupIdAsync<T>(id);
        }
    }
}
