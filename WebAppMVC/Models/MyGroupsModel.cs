﻿using WebAPI.Models;

namespace WebAppMVC.Models
{
    public class MyGroupsModel
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public UnitGroupWithSpecificationModel[] Groups { get; set; }
    }
}
