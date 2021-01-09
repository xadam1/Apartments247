using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using WebAPI.Models;

namespace MVC.Models
{
    public class ListGroupsModel
    {
        public UnitGroupWithSpecificationModel[] Groups { get; set; }
    }
}
