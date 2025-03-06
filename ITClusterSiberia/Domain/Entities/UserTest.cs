using Xunit;
using FluentAssertions;
namespace Domain.Entities;

public class UserTest
{
    #region UserInfo_Test

    [Theory]
    [InlineData("Роман", "Казанцев")]
    [InlineData("Nikolay", "Eger")]
    public void UserInfo_Valid_Test(string firstName, string lastName)
    {
        var act = () =>
        {
            var userInfo = new UserInfo(firstName, lastName);
        };
        act.Should().NotThrow<ArgumentException>();
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("Очень-очень-очень-очень-очень-очень длинноеееееее имя", "")]
    [InlineData("Очень-очень-очень-очень-очень-очень длинноеееееее имя", "Очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень длинная фамилия")]
    [InlineData("", "Очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень-очень длинная фамилия")]
    public void UserInfo_Invalid_Test(string firstName, string lastName)
    {
        var act = () =>
        {
            var userInfo = new UserInfo(firstName, lastName);
        };
        act.Should().Throw<ArgumentException>();
    }
    
    #endregion
    
    #region ContactInfo_Test
    
    [Theory]
    [InlineData("test@test.com", "89131234567")]
    [InlineData("hello@m.r", "+79231234567")]
    public void ContactInfo_Valid_Test(string email, string phoneNumber)
    {
        var act = () =>
        {
            var contactInfo = new ContactInfo(email, phoneNumber);
        };
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("test")]
    [InlineData("test@")]
    [InlineData("test@test")]
    public void ContactInfo_Invalid_Test(string email)
    {
        var act = () =>
        {
            var contactInfo = new ContactInfo(email, "");
        };
        act.Should().Throw<ArgumentException>();
    }
    
    #endregion

    #region AccountData_Test

    [Theory]
    [InlineData("userName", "password")]
    public void AccountData_Valid_Test(string userName, string password)
    {
        var act = () =>
        {
            var accountData = new AccountData(userName, password);
        };
        act.Should().NotThrow<ArgumentException>();
    }

    [Theory]
    [InlineData("", "")]
    public void AccountData_Invalid_Test(string userName, string password)
    {
        var act = () =>
        {
            var accountData = new AccountData(userName, password);
        };
        act.Should().Throw<ArgumentException>();
    }
    
    #endregion
}