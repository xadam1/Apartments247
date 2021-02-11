using DAL.Models;

namespace BLL.DTOs
{
    public class UnitShowDTO
    {
        public Specification Specification { get; set; }

        public string Name => Specification?.Name;

        public UnitType Type { get; set; }

        public int CurrentCapacity { get; set; }

        public int MaxCapacity { get; set; }
    }
}
