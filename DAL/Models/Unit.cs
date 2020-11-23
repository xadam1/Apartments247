using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.SqlClient;

namespace DAL.Models
{
    public class Unit : BaseEntity
    {
        public string Name { get; set; }

        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }

        public int UnitTypeId { get; set; }

        [ForeignKey(nameof(UnitTypeId))]
        public virtual UnitType Type { get; set; }

        public int SpecificationId { get; set; }

        [ForeignKey(nameof(SpecificationId))]
        public virtual Specification Specification { get; set; }

        public Unit(SqlDataReader reader) : this(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)) { }
        public Unit(int id, string name, int currentCapacity, int maxCapacity, int type)
        {
            Id = id;
            Name = name;
            CurrentCapacity = currentCapacity;
            MaxCapacity = maxCapacity;
            UnitTypeId = type;
        }
    }
}