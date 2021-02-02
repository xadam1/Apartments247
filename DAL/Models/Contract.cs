using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Contract : BaseEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }

        public byte[] Content { get; set; }
    }
}