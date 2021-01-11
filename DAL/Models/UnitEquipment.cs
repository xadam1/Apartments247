namespace DAL.Models
{
    public class UnitEquipment : BaseEntity
    {
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}