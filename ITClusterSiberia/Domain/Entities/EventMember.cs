namespace Domain.Entities;

public class EventMembers : EntityBase
{
    public Guid EventId { get; init; }
    public Guid UserId { get; init; }
}