namespace Domain.Entities;

//TODO: Добавить валидацию
public class Event : EntityBase
{
    public Event(string title, string description, DateTime eventDate, Guid? id = null,
        IReadOnlyCollection<Guid>? eventMemberIds = null, IReadOnlyCollection<Guid>? eventAttachmentIds = null)
        : base(id)
    {
        Title = title;
        Description = description;
        EventDate = eventDate;
        EventMemberIds = eventMemberIds ?? [];
        EventAttachmentIds = eventAttachmentIds ?? [];
    }

    public string Title { get; protected set; }
    public string? Description { get; protected set; }
    public DateTime EventDate { get; protected set; }

    public IReadOnlyCollection<Guid> EventMemberIds { get; protected set; } = [];
    public IReadOnlyCollection<Guid> EventAttachmentIds { get; protected set; } = [];
}