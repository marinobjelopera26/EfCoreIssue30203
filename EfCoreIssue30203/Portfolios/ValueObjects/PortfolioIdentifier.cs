using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.Portfolios.ValueObjects;

public sealed class PortfolioIdentifier : ValueObject
{
    public string Value { get; private set; }

    private PortfolioIdentifier(string value)
    {
        Value = value;
    }

    public static PortfolioIdentifier Create(string value)
    {
        return new PortfolioIdentifier(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}