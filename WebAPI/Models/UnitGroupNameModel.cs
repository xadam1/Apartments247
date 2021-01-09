using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UnitGroupNameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UnitGroupNameModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
