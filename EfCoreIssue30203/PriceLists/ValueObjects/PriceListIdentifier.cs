using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.PriceLists.ValueObjects;

public sealed class PriceListIdentifier : ValueObject
{
    public Guid Value { get; private set; }

    private PriceListIdentifier(Guid value)
    {
        Value = value;
    }

    public static PriceListIdentifier Create(Guid value)
    {
        return new PriceListIdentifier(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}