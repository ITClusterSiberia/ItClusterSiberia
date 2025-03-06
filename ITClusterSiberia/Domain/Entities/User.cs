using System.Text.RegularExpressions;

namespace Domain.Entities;

public class User : EntityBase
{
    public User(UserInfo userInfo, ContactInfo contactInfo, AccountData accountData, DateTime birthDate)
    {
        if (birthDate > DateTime.Now)
        {
            throw new ArgumentException("Дата рождения не может быть позднее текущей даты.");
        }
        BirthDate = birthDate;
        UserInfo = userInfo;
        AccountData = accountData;
        ContactInfo = contactInfo;
    }
    
    public UserInfo UserInfo { get; protected set; }
    public string FullName => UserInfo.ToString();
    
    public DateTime BirthDate { get; protected set; }
    public int Age => (DateTime.Now - BirthDate).Days / 365;
    
    public ContactInfo ContactInfo { get; protected set; }
    
    public AccountData AccountData { get; protected set; }
}

public class UserInfo
{
    private readonly Regex _regexFirstName = new(@"^[a-zA-Zа-яА-Я]{1,60}$");
    private readonly Regex _regexLastName = new(@"^[a-zA-Zа-яА-Я]{1,100}$");
    
    private string _firstName;
    private string _lastName;
    
    public UserInfo(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    
    public string FirstName
    {
        get => _firstName;
        set => _firstName = (_regexFirstName.IsMatch(value))
            ? value
            : throw new ArgumentException("Некорректное имя.");
    }
    
    public string LastName
    {
        get => _lastName;
        set => _lastName = (_regexLastName.IsMatch(value))
            ? value
            : throw new ArgumentException("Некорректная фамилия.");
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
    
    public override bool Equals(object? obj)
    {
        var userInfo = obj as UserInfo;
        if (userInfo is null)
        {
            return false;
        }
        return FirstName == userInfo.FirstName && LastName == userInfo.LastName;
    }
}

public class ContactInfo
{
    private readonly Regex _regexEmail = new(@"^\S+@\S+[.]\w+$");
    private readonly Regex _regexPhoneNumber = new(@"^(\+7|8)\d{10}$");
    
    private string _email;
    private string _phoneNumber;

    public ContactInfo(string email, string phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
    }
    
    public string Email
    {
        get => _email;
        set => _email = _regexEmail.IsMatch(value)
            ? value
            : throw new ArgumentException("Некорректный email.");
    }
    
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = _regexPhoneNumber.IsMatch(value)
            ? value
            : throw new ArgumentException("Некорректный номер телефона");
    }

    public override string ToString()
    {
        return $"Email: {Email}\n Phone number: {PhoneNumber}";
    }
    
    public override bool Equals(object? obj)
    {
        var contactInfo = obj as ContactInfo;
        if (contactInfo is null)
        {
            return false;
        }
        return Email == contactInfo.Email && PhoneNumber == contactInfo.PhoneNumber;
    }
}

public class AccountData
{
    private readonly Regex _regexUserName = new(@"^(?=.*\S)[ a-zA-Zа-яА-Я0-9]{8,150}[^\s]$"); 
    private readonly Regex _regexPassword = new(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$");
    
    private string _userName;
    private string _password;
    
    public AccountData(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
    
    public string UserName
    {
        get => _userName;
        set => _userName = (value.Length is >= 4 and <= 150)
            ? value
            : value.Length < 8
                ? throw new ArgumentException("Слишком короткое имя пользователя. Минимальный размер = 4.")
                : throw new AggregateException("Слишком длинное имя пользователя. Максимальный размер = 150.");
    }
    
    public string Password
    {
        get => _password;
        set => _password = (value.Length is >= 8 and <= 20)
            ? value
            : value.Length < 8
                ? throw new ArgumentException("Слишком короткий пароль. Минимальный размер = 4.")
                : throw new AggregateException("Слишком длинный пароль. Максимальный размер = 20.");
    }

    public override string ToString()
    {
        return UserName;
    }

    public override bool Equals(object? obj)
    {
        var accountData = obj as AccountData;
        if (accountData is null)
        {
            return false;
        }
        return UserName == accountData.UserName && Password == accountData.Password;
    }
}