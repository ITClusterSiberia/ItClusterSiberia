namespace Domain.Entities;

public class MemberRole : EntityBase
{
    private string _name = string.Empty;

    public MemberRole(string name, Guid? id = null, IReadOnlyCollection<Guid>? eventMemberIds = null)
        : base(id)
    {
        Name = name;
        EventMemberIds = eventMemberIds ?? [];
    }

    public string Name
    {
        get => _name;
        protected set => _name = value.Length <= 200
            ? value
            : throw new ArgumentException("Длина названия роли не может превышать 200 символов.");
    }

    public IReadOnlyCollection<Guid> EventMemberIds { get; protected set; }
}