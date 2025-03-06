namespace Domain.Entities;

public class Event : EntityBase
{
    public string Title { get; protected set; }
    public string? Description { get; protected set; }
}