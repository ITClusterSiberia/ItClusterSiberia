namespace Domain.Entities;

public class EventMember : EntityBase
{
    public EventMember(Guid eventId, Guid userId, Guid roleId, Guid? id = null)
        : base(id)
    {
        EventId = eventId;
        UserId = userId;
        RoleId = roleId;
    }

    public Guid EventId { get; protected set; }
    public Guid UserId { get; protected set; }
    public Guid RoleId { get; protected set; }
}