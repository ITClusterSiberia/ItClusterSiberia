namespace Domain.Entities;

public class EventMembers : EntityBase
{
    public Guid EventId { get; protected set; }
    public Guid UserId { get; protected set; }
}