using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using WebAPI.Models;

namespace MVC.Models
{
    public class ListUnitsModel
    {
        public int UnitGroupId { get; set; }
        public UnitGroupNameModel[] Groups { get; set; }
        public UnitWithSpecificationModel[] Units { get; set; }
    }
}
