using BLL.Services;
using Infrastructure;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public class ColorFacade : IColorFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IColorService _colorService;

        public ColorFacade(IUnitOfWork unitOfWork, IColorService colorService)
        {
            _unitOfWork = unitOfWork;
            _colorService = colorService;
        }

        public async Task<T[]> GetColorsAsync<T>()
        {

            return await _colorService.GetColorsAsync<T>();
        }
    }
}
