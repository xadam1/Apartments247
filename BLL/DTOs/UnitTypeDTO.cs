using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UnitTypeDTO
    {
        [StringLength(64)]
        public string Type { get; set; }
    }
}
