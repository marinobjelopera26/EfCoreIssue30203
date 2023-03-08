using EfCoreIssue30203.Domain.Abstractions;

namespace EfCoreIssue30203.Domain.Coverages.ValueObjects;

public sealed class CoverageId : ValueObject
{
    public Guid Value { get; }

    private CoverageId(Guid value)
    {
        Value = value;
    }

    public static CoverageId CreateUnique()
    {
        return new CoverageId(Guid.NewGuid());
    }

    public static CoverageId Create(Guid value)
    {
        return new CoverageId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}