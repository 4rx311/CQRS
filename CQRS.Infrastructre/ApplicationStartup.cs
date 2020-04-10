using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CQRS.Domain.Products;
using CQRS.Infrastructre.Domain;
using CQRS.Infrastructre.Domain.Products;
using CQRS.Infrastructre.Processing.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Infrastructre
{
    public sealed class ApplicationStartup
    {
        public static IServiceProvider Initialize(IServiceCollection services)
        {
            return CreateAutofacServiceProvider(services);
        }

        public static IServiceProvider CreateAutofacServiceProvider(IServiceCollection services)
        {
            var container = new ContainerBuilder();

            //Объединяем сервисы DI Net Core & Autofac
            container.Populate(services);

            container.RegisterType<ProductRepository>().As<IProductRepository>();
            container.RegisterModule<MediatorModule>();
            container.RegisterModule<DomainModule>();

            var buildContainer = container.Build();
            CompositionRoot.SetContainer(buildContainer);

            //Создаём провайдер который будет реализовать DI через ServiceLocator и использоваться в Net Core
            var serviceProvider = new AutofacServiceProvider(buildContainer);
            return serviceProvider;
        }
    }
}
