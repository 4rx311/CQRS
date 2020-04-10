using System.Threading.Tasks;
using CQRS.Application;
using CQRS.Application.Products;
using CQRS.Application.Products.RegisterProduct;
using MediatR;

namespace CQRS.API.Products
{
    public class ProductController
    {
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        public async Task<ProductDto> Register(RegisterProductRequest request)
        {
            var command = new RegisterProductCommand(request.Name, request.Cost);
            var result = await _mediator.Send(command);

            return result;
        }
    }
}
