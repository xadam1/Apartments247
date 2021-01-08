using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace WebAPI.Models
{
    public class UnitGroupWithSpecificationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public int AddressId { get; set; }
        public string Note { get; set; }
    }
}
