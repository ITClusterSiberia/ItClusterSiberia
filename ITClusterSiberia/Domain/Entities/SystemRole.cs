namespace Domain.Entities;

//TODO: Добавить валидацию
public class SystemRole : EntityBase
{
    public SystemRole(string name, Guid? id = null, IReadOnlyCollection<Guid>? userIds = null)
        : base(id)
    {
        Name = name;
        UserIds = userIds ?? [];
    }

    public string Name { get; protected set; }

    public IReadOnlyCollection<Guid> UserIds { get; protected set; } = [];
}