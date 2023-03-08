using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.PriceLists.ValueObjects;

public sealed class PriceListId : ValueObject
{
    public Guid Value { get; private set; }

    private PriceListId(Guid value)
    {
        Value = value;
    }

    public static PriceListId CreateUnique()
    {
        return new PriceListId(Guid.NewGuid());
    }

    public static PriceListId Create(Guid value)
    {
        return new PriceListId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}