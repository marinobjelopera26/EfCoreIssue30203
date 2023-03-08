using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.Coverages;

public class CoverageName : ValueObject
{
    public string Value { get; }

    private CoverageName(string value)
    {
        Value = value;
    }

    public static CoverageName Create(string value)
    {
        return new CoverageName(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}