using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using WebAPI.Models;

namespace MVC.Models
{
    public class MyGroupsModel
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public UnitGroupWithSpecificationModel[] Groups { get; set; }
    }
}
