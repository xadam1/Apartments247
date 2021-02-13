using AutoMapper;
using BLL.DTOs;
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
            throw new System.NotImplementedException();
        }

        public void DeleteEquipment(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<T>> GetEquipmentsByUnitIdAsync<T>(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateEquipmentAsync(int id, EquipmentDTO equipmentDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
