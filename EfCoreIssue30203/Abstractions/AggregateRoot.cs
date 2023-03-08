namespace EfCoreIssue30203.Domain.Abstractions;

public abstract class AggregateRoot<TId> 
    : Entity<TId> where TId : notnull
{
    protected AggregateRoot(TId id) : base(id)
    {
    }

    protected AggregateRoot() : base()
    {
    }
}
