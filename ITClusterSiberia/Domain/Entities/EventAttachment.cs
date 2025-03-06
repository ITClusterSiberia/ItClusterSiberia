namespace Domain.Entities;

public class EventAttachment : EntityBase
{
    public string FileName { get; protected set; }
    public string? Description { get; protected set; }
    public string FilePath { get; protected set; }

    public Guid EventId { get; protected set; }
}