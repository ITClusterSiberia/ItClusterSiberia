using Application.DataTransferObjects;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/authentication")]
public class AuthController : Controller
{
    private readonly IUserRepository _userRepository;
    
    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] AccountData accountData)
    {
        var user = await _userRepository.GetByAccountData(accountData);
        if (user is null)
        {
            return Unauthorized();
        }
        return Ok(user);
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] UserDto userDto)
    {
        var accountData = new AccountData(userDto.UserName, userDto.Password);
        var userInfo = new UserInfo(userDto.FirstName, userDto.LastName);
        var contactInfo = new ContactInfo(userDto.Email, userDto.PhoneNumber);
        var user = new User(userInfo, contactInfo, accountData, userDto.BirthDate, userDto.SystemRoleId);
        return await _userRepository.AddAsync(user) ? Ok() : BadRequest();
    }
}