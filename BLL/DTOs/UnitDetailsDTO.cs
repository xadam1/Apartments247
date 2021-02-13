using DAL.Entities;

namespace BLL.DTOs
{
    public class UnitDetailsDTO
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public int MaxCapacity { get; set; }

        public int CurrentCapacity { get; set; }

        public UnitType UnitType { get; set; }

        public UnitGroup UnitGroup { get; set; }

        public string? TypeStr => UnitType?.Type;

        public virtual Specification Specification { get; set; }

        public string? Note => Specification.Note;

        public Contract Contract { get; set; }

        public int MonthlyIncome { get; set; }
    }
}