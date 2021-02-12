using System.Collections.Generic;

namespace BLL.DTOs
{
    public class CreateGroupDTO
    {
        public IEnumerable<ColorDTO> Colors { get; set; }
    }
}