namespace Domain.Primitives;
public abstract class BaseEntity<TEntityId>
{
    public TEntityId Id { get; init; }

    protected BaseEntity(TEntityId id)
    {
        Id = id;
    }
    protected BaseEntity()
    {
    }
}
