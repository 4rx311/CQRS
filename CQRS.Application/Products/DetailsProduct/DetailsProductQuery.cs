using System;

namespace CQRS.Application.Products.DetailsProduct
{
    public sealed class DetailsProductQuery : IQuery<ProductDto>
    {
        public DetailsProductQuery(Guid id)
        {
            ID = id;
        }

        public Guid ID { get; }
    }
}
