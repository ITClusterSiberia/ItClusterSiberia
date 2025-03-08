using System.Text.RegularExpressions;

namespace Domain.Entities;

//TODO: Добавить тесты
public class EventAttachment : EntityBase
{
    private readonly Regex _regexFile = new(@"^(?=.*\S)[\S\s]+\.\S+$");

    private string _fileName;
    private string _filePath;

    public EventAttachment(string fileName, string? description, string filePath, Guid eventId, Guid? id = null)
        : base(id)
    {
        FileName = fileName;
        Description = description;
        FilePath = filePath;
        EventId = eventId;
    }

    public string FileName
    {
        get => _fileName;
        protected set => _fileName = (_regexFile.IsMatch(value))
            ? value
            : throw new ArgumentException("Некорректное имя файла.");
    }

    public string? Description { get; protected set; }

    public string FilePath
    {
        get => _filePath;
        protected set => _filePath = (_regexFile.IsMatch(value))
            ? value
            : throw new ArgumentException("Некорректный путь файла.");
    }

    public Guid EventId { get; protected set; }
}