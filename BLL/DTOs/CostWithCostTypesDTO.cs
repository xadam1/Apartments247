using DAL.Extras;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class CostWithCostTypesDTO
    {
        public CostDTO CostDTO { get; set; }

        public IEnumerable<SelectListItem> CostTypes { get; set; }
    }
}
