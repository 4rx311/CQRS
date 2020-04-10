using CQRS.Domain.Products;
using FluentValidation;

namespace CQRS.Application.Products.RegisterProduct
{
    public sealed class RegisterProductValidator : AbstractValidator<RegisterProductCommand>
    {
        public RegisterProductValidator(IProductUniquenessChecker uniquenessChecker)
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Cost).GreaterThan(0d);
            RuleFor(p => p.Name)
                .Must(name => uniquenessChecker.IsUniqueName(name) == true)
                .WithMessage(command => $"Продукт с названием '{command.Name}' уже содержится в базе");
        }
    }
}
