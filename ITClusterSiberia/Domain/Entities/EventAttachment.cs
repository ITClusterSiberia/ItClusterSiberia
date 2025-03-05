public class EventAttachment : EntityBase
{
    public string FileName { get; init; }
    public string? Description { get; init; }
    public string FilePath { get; init; }

    public Guid EventId { get; init; }
}