using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class AddressCityLocalDTO
    {
        [StringLength(64)]
        public string Street { get; set; }

        [StringLength(64)]
        public string Number { get; set; }
    }
}
