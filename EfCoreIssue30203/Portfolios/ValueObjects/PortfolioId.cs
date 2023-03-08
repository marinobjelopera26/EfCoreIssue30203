using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.Portfolios.ValueObjects;

public sealed class PortfolioId : ValueObject
{
    public Guid Value { get; private set; }

    private PortfolioId(Guid value)
    {
        Value = value;
    }

    public static PortfolioId CreateUnique()
    {
        return new PortfolioId(Guid.NewGuid());
    }

    public static PortfolioId Create(Guid value)
    {
        return new PortfolioId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}