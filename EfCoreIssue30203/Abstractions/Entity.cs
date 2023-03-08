namespace EfCoreIssue30203.Domain.Abstractions;

public abstract class Entity<TId> where TId : notnull
{
    public TId Id { get; private set; }

#pragma warning disable CS8618
    protected Entity()
    {
    }
#pragma warning restore CS8618

    protected Entity(TId id)
    {
        Id = id;
    }
}
