using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UnitWithSpecificationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
        public int AddressId { get; set; }
        public string Note { get; set; }
        public int UnitTypeId { get; set; }
        public string UnitType { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public string ContractLink { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
    }
}
