using Autofac;
using CQRS.Application.Products.DomainServices;
using CQRS.Domain.Products;

namespace CQRS.Infrastructre.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductUniquenessChecker>()
                .As<IProductUniquenessChecker>()
                .InstancePerLifetimeScope();
        }
    }
}
