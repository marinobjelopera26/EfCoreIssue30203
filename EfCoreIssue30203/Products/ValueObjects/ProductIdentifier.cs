using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.Products.ValueObjects;

public sealed class ProductIdentifier : ValueObject
{
    public const int MaxLength = 20;

    public string Value { get; private set; }

    private ProductIdentifier(string value)
    {
        Value = value;
    }

    public static ProductIdentifier Create(string value)
    {
        return new ProductIdentifier(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}