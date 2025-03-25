namespace Domain.Entities;

public class Event : EntityBase
{
    private string _title = string.Empty;

    public Event(string title, string description, DateTime eventDate, IReadOnlyCollection<Guid> eventMemberIds, string address, Guid? id = null, IReadOnlyCollection<Guid>? eventAttachmentIds = null)
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
        Address = address;
        EventAttachmentIds = eventAttachmentIds ?? [];
    }

    public string Title
    {
        get => _title;
        protected set => _title = value.Length <= 300
            ? value
            : throw new ArgumentException("Длина названия не может быть более 300 символов.");
    }

    public string? Description { get; protected set; }
    public DateTime EventDate { get; protected set; }
    public string Address { get; protected set; }

    public IReadOnlyCollection<Guid> EventMemberIds { get; protected set; }
    public IReadOnlyCollection<Guid> EventAttachmentIds { get; protected set; }
}