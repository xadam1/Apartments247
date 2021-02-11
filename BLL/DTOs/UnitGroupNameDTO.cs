using DAL.Models;

namespace BLL.DTOs
{
    public class UnitGroupNameDTO
    {
        public int Id { get; set; }
        public Specification Specification { get; set; }

        public string Name => Specification?.Name;
    }
}
