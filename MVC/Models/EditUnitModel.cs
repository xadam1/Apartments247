using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Extras;
using DAL.Models;
using WebAPI.Models;

namespace MVC.Models
{
    public class EditUnitModel
    {
        public UnitWithSpecificationModel Unit { get; set; }
        public Color[] Colors { get; set; }
        public UnitTypeModel[] UnitTypes { get; set; }
    }
}
