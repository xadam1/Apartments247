namespace BLL.DTOs
{
    public class AddressDTO
    {
        public string Street { get; set; }

        public string Number { get; set; }

#nullable enable
        public string? Zip { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }
    }
}
