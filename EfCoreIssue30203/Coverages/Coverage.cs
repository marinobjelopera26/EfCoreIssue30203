using EfCoreIssue30203.Domain.Coverages.ValueObjects;
using EfCoreIssue30203.Domain.Products.Entities;
using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.Coverages;

public sealed class Coverage : AggregateRoot<CoverageId>
{
#pragma warning disable CS8618
    private Coverage()
    {
    }
#pragma warning restore CS8618

    public CoverageIdentifier Identifier { get; private set; }

    public CoverageName Name { get; private set; }
}
