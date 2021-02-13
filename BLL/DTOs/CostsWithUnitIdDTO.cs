using X.PagedList;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class CostsWithUnitIdDTO
    {
        public IPagedList<CostDTO> CostsDTO { get; set; }

        public int UnitId { get; set; }
    }
}
