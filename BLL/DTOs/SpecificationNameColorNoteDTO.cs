using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace BLL.DTOs
{
    public class SpecificationNameColorNoteDTO
    {
        [StringLength(128)]
        public string Name { get; set; }

        public Color Color { get; set; }

        [StringLength(1024)]
        public string Note { get; set; }
    }
}