using System.Collections.Generic;
using BLL.Services;
using Infrastructure;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public class UnitTypeFacade : IUnitTypeFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitTypeService _unitTypeService;

        public UnitTypeFacade(IUnitOfWork unitOfWork, IUnitTypeService unitTypeService)
        {
            _unitOfWork = unitOfWork;
            _unitTypeService = unitTypeService;
        }

        public async Task<List<T>> GetUnitTypesAsync<T>()
        {
            return await _unitTypeService.GetUnitTypesAsync<T>();
        }
    }
}
