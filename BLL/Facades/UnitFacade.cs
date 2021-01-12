using BLL.DTOs;
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

        public async Task CreateUnitAsync(UnitDTO unitDTO)
        {
            _unitService.CreateUnit(unitDTO);

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateUnitAsync(int id, UnitDTO unitDTO)
        {
            await _unitService.UpdateUnitAsync(id, unitDTO);

            await _unitOfWork.CommitAsync();
        }
    }
}
