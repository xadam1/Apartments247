using Autofac;
using DAL;
using Infrastructure.Queries;
using Module = Autofac.Module;

namespace Infrastructure
{
    public class AutofacInfrastructureConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();

            // Register all queries
            builder.RegisterType<AddressQuery>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<SpecificationQuery>()
                .AsSelf()
                .InstancePerDependency();
            
            builder.RegisterType<UnitGroupQuery>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<UnitGroupsWithUsersQuery>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<UnitGroupsWithUsersWithSpecificationsQuery>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<UnitQuery>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<UnitTypeQuery>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<UserQuery>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<ApartmentsDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}