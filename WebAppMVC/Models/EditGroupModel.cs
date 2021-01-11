using DAL.Models;

namespace WebAppMVC.Models
{
    public class EditGroupModel
    {
        public int Id { get; set; }
        public UnitType[] UnitTypes { get; set; }
        public UnitGroup Group { get; set; }
    }
}
