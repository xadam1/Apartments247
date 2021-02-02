using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Extras;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAPI.Models;

namespace WebAppMVC.Models
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
        public IFormFile FormFile { get; set; }
    }
}
