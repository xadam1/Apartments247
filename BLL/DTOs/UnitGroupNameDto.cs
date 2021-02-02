using DAL.Models;

namespace BLL.DTOs
{
    public class UnitGroupNameDto
    {
        public int Id { get; set; }
        public Specification Specification { get; set; }

        public string Name => Specification.Name;
    }
}
