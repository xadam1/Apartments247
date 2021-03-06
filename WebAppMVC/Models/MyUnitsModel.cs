﻿using WebAPI.Models;

namespace WebAppMVC.Models
{
    public class MyUnitsModel
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public UnitGroupNameModel[] Groups { get; set; }
        public UnitWithSpecificationModel[] Units { get; set; }
    }
}
