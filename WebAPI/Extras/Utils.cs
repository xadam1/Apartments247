using DAL.Models;
using WebAPI.Models;

namespace WebAPI.Extras
{
    public static class Utils
    {
        public static UnitGroupWithSpecificationModel Convert(UnitGroup group)
        {
            return new UnitGroupWithSpecificationModel()
            {
                Id = group.Id,
                UserId = group.UserId,
                Name = group.Specification.Name,
                Color = group.Specification.Color,
                AddressId = group.Specification.AddressId,
                Note = group.Specification.Note
            };
        }
    }
}
