using System;
using System.Threading.Tasks;
using Autofac;
using CQRS.API.Products;
using CQRS.Application.Products.RegisterProduct;
using CQRS.Infrastructre;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.API
{
    class Program
    {
        //имитация веб-приложения и его встроенного DI
        private IServiceProvider ServiceProvider { get; set; }


        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.Run();
            Console.ReadKey();
        }

        public async Task Run()
        {
            //в веб-приложении вызов ConfigureServices происходит внутри ASP.Net
            //с аргументом IServiceCollection
            ConfigureServices(new ServiceCollection());

            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                var productController = new ProductController(mediator);
                var productDto1 = await productController.Register(new RegisterProductRequest()
                {
                    Name = "Apple",
                    Cost = 150d
                });
                Console.WriteLine($"{productDto1.Name}, {productDto1.Cost}");

                var productDto2 = await productController.Register(new RegisterProductRequest()
                {
                    Name = "Apple",
                    Cost = 170d
                });
                Console.WriteLine($"{productDto2.Name}, {productDto2.Cost}");
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            ServiceProvider = ApplicationStartup.Initialize(services);
        }
    }
}
