namespace CQRS.Domain.Products
{
    public interface IProductUniquenessChecker
    {
        bool IsUniqueName(string name);
    }
}
