using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class AddressFullDTO
    {
        [StringLength(64)]
        public string State { get; set; }

        [StringLength(64)]
        public string City { get; set; }

        [StringLength(64)]
        public string Street { get; set; }

        [StringLength(64)]
        public string Number { get; set; }

        [StringLength(64)]
        public string Zip { get; set; }
    }
}
