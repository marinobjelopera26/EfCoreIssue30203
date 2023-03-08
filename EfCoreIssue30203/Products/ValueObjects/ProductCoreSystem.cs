using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.Products.ValueObjects;

public sealed class ProductCoreSystem : ValueObject
{
    public const int IdentifierLength = 3;
    public const int CodeMaxLength = 30;

    private ProductCoreSystem(
        string identifier,
        string code)
    {
        Identifier = identifier;
        Code = code;
    }

    public string Identifier { get; private set; }
    public string Code { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Identifier;
        yield return Code;
    }
}
