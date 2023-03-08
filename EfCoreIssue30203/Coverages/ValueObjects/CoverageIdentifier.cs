namespace EfCoreIssue30203.Domain.Products.Entities;

public class CoverageIdentifier
{
    public const int MaxLength = 25;

    public string Value { get; private set; }

    private CoverageIdentifier(string value)
    {
        Value = value;
    }

    public static CoverageIdentifier Create(string value)
    {
        return new CoverageIdentifier(value);
    }
}