using BLL.DTOs;
using BLL.Services;
using Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public class EquipmentFacade : IEquipmentFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEquipmentService _equipmentService;

        public EquipmentFacade(IUnitOfWork unitOfWork, IEquipmentService equipmentService)
        {
            _unitOfWork = unitOfWork;
            _equipmentService = equipmentService;
        }

        public async Task CreateEquipmentAsync<T>(T equipmentDTO)
        {
            _equipmentService.CreateEquipment<T>(equipmentDTO);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            _equipmentService.DeleteEquipment(id);

            await _unitOfWork.CommitAsync();
        }

        public async Task<List<T>> GetEquipmentsByUnitIdAsync<T>(int id)
        {
            return await _equipmentService.GetEquipmentsByUnitIdAsync<T>(id);
        }

        public async Task UpdateEquipmentAsync(EquipmentDTO equipmentDTO)
        {
            await _equipmentService.UpdateEquipmentAsync(equipmentDTO);

            await _unitOfWork.CommitAsync();
        }
    }
}
