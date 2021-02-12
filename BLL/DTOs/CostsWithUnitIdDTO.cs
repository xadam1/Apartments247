using System.Collections.Generic;

namespace BLL.DTOs
{
    public class CostsWithUnitIdDTO
    {
        public IEnumerable<CostDTO> CostsDTO { get; set; }

        public int UnitId { get; set; }
    }
}
