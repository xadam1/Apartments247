using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace MVC.Models
{
    public class EditGroupModel
    {
        public int Id { get; set; }
        public UnitType[] UnitTypes { get; set; }
        public UnitGroup Group { get; set; }
    }
}
