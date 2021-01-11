using AutoMapper;
using BLL.DTOs;
using Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ColorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<T[]> GetColorsAsync<T>()
        {
            var colors = (await _unitOfWork.ColorRepository.GetAllAsync()).ToArray();

            return _mapper.Map<T[]>(colors);
        }
    }
}
