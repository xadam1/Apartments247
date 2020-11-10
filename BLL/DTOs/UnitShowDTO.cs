using DAL.Models;

namespace BLL.DTOs
{
    public class UnitShowDTO
    {
        public UnitType Type { get; set; }

        public int CurrentCapacity { get; set; }
    }
}
