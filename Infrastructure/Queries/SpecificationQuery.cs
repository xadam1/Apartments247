using DAL;
using DAL.Entities;

namespace Infrastructure.Queries
{
    public class SpecificationQuery : Query<Specification>
    {
        public SpecificationQuery(ApartmentsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
