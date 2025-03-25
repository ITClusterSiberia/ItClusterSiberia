namespace Application.DataTransferObjects;

public record UserDto(
    DateTime BirthDate, Guid SystemRoleId,
    // UserInfo
    string Email, string PhoneNumber,
    // ContactInfo
    string FirstName, string LastName,
    // AccountData
    string UserName, string Password);