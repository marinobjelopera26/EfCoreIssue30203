using EfCoreIssue30203.Domain.Abstractions;
using EfCoreIssue30203.Domain.Portfolios.ValueObjects;
using EfCoreIssue30203.Domain.Products.ValueObjects;

namespace EfCoreIssue30203.Domain.Portfolios;

public sealed class Portfolio : AggregateRoot<PortfolioId>
{
    private readonly List<ProductId> _productIds = new();

#pragma warning disable CS8618
    private Portfolio()
    {
    }
#pragma warning restore CS8618

    public PortfolioIdentifier Identifier { get; private set; }

    public IReadOnlyCollection<ProductId> ProductIds => _productIds.AsReadOnly();

    // OTHER IMPLEMENTATIONS BELOW
}