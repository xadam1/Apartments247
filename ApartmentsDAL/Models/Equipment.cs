using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentsDAL.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        public int UnitId { get; set; }

        [ForeignKey(nameof(UnitId))]
        public Unit Unit { get; set; }

        public ICollection<EquipmentType> AvailableEquipment{ get; set; }
    }
}