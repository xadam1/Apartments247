using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateEquipment<T>(T equipmentDTO)
        {
            _unitOfWork.EquipmentRepository.Add(_mapper.Map<Equipment>(equipmentDTO));
        }

        public void DeleteEquipment(int id)
        {
            var equipmentTask = _unitOfWork.EquipmentRepository.GetByIdAsync(id);
            equipmentTask.Wait();

            var equipment = equipmentTask.Result;
            _unitOfWork.EquipmentRepository.Delete(equipment);
        }

        public async Task<List<T>> GetEquipmentsByUnitIdAsync<T>(int id)
        {
            var query = _unitOfWork.EquipmentQuery.FilterByUnitId(id);

            var equipments = await query.ExecuteAsync();
            return _mapper.Map<List<T>>(equipments);
        }

        public async Task UpdateEquipmentAsync(EquipmentDTO equipmentDTO)
        {
            var equipment = await _unitOfWork.EquipmentRepository.GetByIdAsync(equipmentDTO.Id);
            equipment.Type = equipmentDTO.Type;
            equipment.UnitEquipments = equipmentDTO.UnitEquipments;

            _unitOfWork.EquipmentRepository.Update(equipment);
        }
    }
}
