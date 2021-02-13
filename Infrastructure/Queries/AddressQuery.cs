using DAL;
using DAL.Entities;

namespace Infrastructure.Queries
{
    public class AddressQuery : Query<Address>
    {
        public AddressQuery(ApartmentsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
