﻿using DAL.Models;
using WebAPI.Models;

namespace WebAppMVC.Models
{
    public class EditGroupModel
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public bool CreateNew { get; set; }
        public UnitGroupWithSpecificationModel Group { get; set; }
        public Color[] Colors { get; set; }
    }
}
