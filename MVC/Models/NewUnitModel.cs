using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Extras;
using DAL.Models;

namespace MVC.Models
{
    public class NewUnitModel
    {
        public UnitType[] UnitTypes { get; set; }
        public Color[] Colors { get; set; }
    }
}
