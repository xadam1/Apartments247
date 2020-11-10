using System.ComponentModel.DataAnnotations;
using DAL.Extras;

namespace BLL.DTOs
{
    public class SpecificationNameColorDTO
    {
        [StringLength(128)]
        public string Name { get; set; }

        public Color Color { get; set; }
    }
}