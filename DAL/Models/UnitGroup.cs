using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.SqlClient;

namespace DAL.Models
{
    public class UnitGroup : BaseEntity
    {
        public int SpecificationId { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }

        [ForeignKey(nameof(SpecificationId))]
        public virtual Specification Specification { get; set; }
        
        public virtual ICollection<Unit> Units { get; set; }

        public UnitGroup(SqlDataReader reader) : this(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4)) { }

        public UnitGroup(int id, string name, int color, string note, string address)
        {
            SpecificationId = id;
            Name = name;
            Color = color;
            Note = note;
            Address = address;
        }
    }
}