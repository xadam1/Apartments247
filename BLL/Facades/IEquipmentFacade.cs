using BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IEquipmentFacade
    {
        Task<List<T>> GetEquipmentsByUnitIdAsync<T>(int id);

        Task CreateEquipmentAsync<T>(T equipmentDTO);

        Task UpdateEquipmentAsync(EquipmentDTO equipmentDTO);

        Task DeleteEquipmentAsync(int id);
    }
}
