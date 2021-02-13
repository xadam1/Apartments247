using BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IEquipmentService
    {
        Task<List<T>> GetEquipmentsByUnitIdAsync<T>(int id);

        void CreateEquipment<T>(T equipmentDTO);

        Task UpdateEquipmentAsync(int id, EquipmentDTO equipmentDTO);

        void DeleteEquipment(int id);
    }
}
