using DAL.Models;

namespace WebAppMVC.Models
{
    public class ListOfGroupsAndUnitsModel
    {
        public UnitGroup[] Groups { get; set; }
        public Unit[] Units { get; set; }
    }
}
