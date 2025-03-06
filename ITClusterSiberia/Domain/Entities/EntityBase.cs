namespace Domain.Entities;

public abstract class EntityBase 
{
    public Guid Id { get; protected set; } = Guid.CreateVersion7();
}