using DAL.Models;

namespace WebAPI.Models
{
    public class UnitGroupWithSpecificationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
        public int AddressId { get; set; }
        public string Note { get; set; }
    }
}
