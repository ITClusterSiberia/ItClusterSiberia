namespace Domain.Entities;

//TODO: Добавить валидацию
public class MemberRole : EntityBase
{
    public MemberRole(string name, Guid? id = null, IReadOnlyCollection<Guid>? eventMemberIds = null)
        : base(id)
    {
        Name = name;
        EventMemberIds = eventMemberIds ?? [];
    }

    public string Name { get; protected set; }

    public IReadOnlyCollection<Guid> EventMemberIds { get; protected set; } = [];
}