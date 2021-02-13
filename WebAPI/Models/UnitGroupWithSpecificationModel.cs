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
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
    }
}
