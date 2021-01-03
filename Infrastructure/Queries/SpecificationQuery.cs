using DAL;
using DAL.Models;

namespace Infrastructure.Queries
{
    public class SpecificationQuery : Query<Specification>
    {
        public SpecificationQuery(ApartmentsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
