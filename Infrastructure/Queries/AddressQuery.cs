using DAL;
using DAL.Models;

namespace Infrastructure.Queries
{
    public class AddressQuery : Query<Address>
    {
        public AddressQuery(ApartmentsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
