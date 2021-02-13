using X.PagedList;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class CostsWithUnitIdDTO
    {
        public IPagedList<CostDTO> CostsDTO { get; set; }

        public int UnitId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FromDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ToDate { get; set; }
    }
}
