using DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.Entities;

namespace Infrastructure.Queries
{
    public class EquipmentQuery : Query<Equipment>
    {
        public EquipmentQuery(ApartmentsDbContext apartmentsDbContext) : base(apartmentsDbContext)
        {
            _query = _query.Include(equipment => equipment.UnitEquipments);
        }

        /*public EquipmentQuery FilterByUnitId(int unitId)
        {
            _query = _query.Where(equipment => equipment.UnitEquipments. == unitId);
            return this;
        }*/
    }
}