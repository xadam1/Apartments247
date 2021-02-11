using DAL.Models;

namespace BLL.DTOs
{
    public class UnitFullDTO
    {
        public int Id { get; set; }

        public int MaxCapacity { get; set; }

        public int CurrentCapacity { get; set; }

        public int UnitTypeId { get; set; }

        public UnitType UnitType { get; set; }

        public string TypeStr => UnitType?.Type;

        public int SpecificationId { get; set; }

        public virtual Specification Specification { get; set; }

        public string? Note => Specification.Note;

        public Contract Contract { get; set; }

        public int MonthlyIncome { get; set; }
    }
}
