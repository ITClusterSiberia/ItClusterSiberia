namespace Domain.Entities;

public abstract class EntityBase(Guid? id)
{
    public Guid Id { get; protected set; } = id ?? Guid.CreateVersion7();
}