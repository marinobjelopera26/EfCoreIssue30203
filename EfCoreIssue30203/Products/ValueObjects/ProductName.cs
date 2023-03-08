using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.Products.ValueObjects;

public sealed class ProductName : ValueObject
{
    public const int MaxLength = 20;

    public string Value { get; private set; }

    private ProductName(string value)
    {
        Value = value;
    }

    public static ProductName Create(string value)
    {
        return new ProductName(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
