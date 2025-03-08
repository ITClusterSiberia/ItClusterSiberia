namespace Domain.Entities;

//TODO: Добавить валидацию
public class Event : EntityBase
{
    public Event(string title, string description, DateTime eventDate, IReadOnlyCollection<Guid> eventMemberIds,
        Guid? id = null, IReadOnlyCollection<Guid>? eventAttachmentIds = null)
        : base(id)
    {
        if (eventMemberIds.Count == 0)
        {
            throw new ArgumentException("Не указан ни один участник.");
        }
        Title = title;
        Description = description;
        EventDate = eventDate;
        EventMemberIds = eventMemberIds;
        EventAttachmentIds = eventAttachmentIds ?? [];
    }

    public string Title { get; protected set; }
    public string? Description { get; protected set; }
    public DateTime EventDate { get; protected set; }

    public IReadOnlyCollection<Guid> EventMemberIds { get; protected set; } = [];
    public IReadOnlyCollection<Guid> EventAttachmentIds { get; protected set; } = [];
}