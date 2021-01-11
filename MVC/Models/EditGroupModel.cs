using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using WebAPI.Models;

namespace MVC.Models
{
    public class EditGroupModel
    {
        public int UserId { get; set; }
        public UnitGroupWithSpecificationModel Group { get; set; }
        public Color[] Colors { get; set; }
    }
}
