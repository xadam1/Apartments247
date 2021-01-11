using DAL.Models;

namespace BLL.DTOs
{
    public class UnitFullDTO
    {
        public int MaxCapacity { get; set; }

        public int CurrentCapacity { get; set; }

        public int UnitTypeId { get; set; }

        public UnitType Type { get; set; }

        public int SpecificationId { get; set; }

        public virtual Specification Specification { get; set; }
    }
}
