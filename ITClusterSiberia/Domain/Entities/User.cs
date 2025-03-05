namespace Domain.Entities;

public class User : EntityBase
{
    public string UserName { get; init; }
    public string Password { get; init; }
}