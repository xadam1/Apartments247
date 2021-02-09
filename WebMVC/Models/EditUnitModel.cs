using DAL.Models;
using WebAPI.Models;

namespace WebMVC.Models
{
    public class EditUnitModel
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int UnitId { get; set; }
        public UnitGroupNameModel[] UnitGroups { get; set; }
        public UnitWithSpecificationModel Unit { get; set; }
        public Color[] Colors { get; set; }
        public UnitTypeModel[] UnitTypes { get; set; }
        //public IFormFile FormFile { get; set; }
    }
}
