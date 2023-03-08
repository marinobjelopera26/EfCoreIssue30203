using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.Products.Entities;

public sealed class ProductCoverage : Entity<int>
{
#pragma warning disable CS8618
    private ProductCoverage()
    {
    }
#pragma warning restore CS8618

    public CoverageIdentifier Identifier { get; private set; }

    // OTHER IMPLEMENTATIONS BELOW
}
