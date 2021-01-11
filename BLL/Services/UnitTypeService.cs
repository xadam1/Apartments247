using AutoMapper;
using Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UnitTypeService : IUnitTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UnitTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<T[]> GetUnitTypesAsync<T>()
        {
            var unitTypes = (await _unitOfWork.UnitTypeRepository.GetAllAsync()).ToArray();

            return _mapper.Map<T[]>(unitTypes);
        }
    }
}
