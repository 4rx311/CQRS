﻿using System.Threading;
using System.Threading.Tasks;
using CQRS.Domain.Products;

namespace CQRS.Application.Products.DetailsProduct
{
    public sealed class DetailsProductQueryHandler : IQueryHandler<DetailsProductQuery, ProductDto>
    {
        public DetailsProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        private readonly IProductRepository _repository;

        public async Task<ProductDto> Handle(DetailsProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetAsync(request.ID);
            return new ProductDto() {Name = product.Name};
        }
    }
}
