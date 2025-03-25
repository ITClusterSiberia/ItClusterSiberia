namespace Domain.Entities;

public class SystemRole : EntityBase
{
    private string _name = string.Empty;
    
    public SystemRole(string name, Guid? id = null, IReadOnlyCollection<Guid>? userIds = null)
        : base(id)
    {
        Name = name;
        UserIds = userIds ?? [];
    }

    public string Name
    {
        get => _name;
        protected set => _name = value.Length <= 200
            ? value
            : throw new ArgumentException("Длина названия роли не может превышать 200 символов.");
    }

    public IReadOnlyCollection<Guid> UserIds { get; protected set; }
}