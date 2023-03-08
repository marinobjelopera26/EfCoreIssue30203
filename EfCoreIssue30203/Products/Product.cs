using EfCoreIssue30203.Domain.Products.Entities;
using EfCoreIssue30203.Domain.Abstractions;
using EfCoreIssue30203.Domain.Products.ValueObjects;
using EfCoreIssue30203.Domain.Portfolios.ValueObjects;

namespace EfCoreIssue30203.Domain.Products;

public sealed class Product : AggregateRoot<ProductId>
{
    private readonly List<ProductCoverage> _coverages = new();

#pragma warning disable CS8618
    private Product()
    {
    }
#pragma warning restore CS8618

    public ProductIdentifier Identifier { get; private set; }

    public ProductName Name { get; private set; }

    public ProductCoreSystem CoreSystem { get; private set; }

    public PortfolioId PortfolioId { get; private set; }

    public IReadOnlyCollection<ProductCoverage> Coverages => _coverages.AsReadOnly();

    // OTHER IMPLEMENTATIONS BELOW
}
