using DAL.Models;

namespace WebAppMVC.Models
{
    public class NewUnitModel
    {
        public UnitType[] UnitTypes { get; set; }
        public Color[] Colors { get; set; }
    }
}
