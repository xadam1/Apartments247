using DAL.Models;

namespace MVC.Models
{
    public class ListOfGroupsAndUnitsModel
    {
        public UnitGroup[] Groups { get; set; }
        public Unit[] Units { get; set; }
    }
}
