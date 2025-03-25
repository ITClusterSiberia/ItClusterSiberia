using Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/systemrole")]
public class SystemRoleController : Controller
{
    private readonly ISystemRoleRepository _systemRoleRepository;

    public SystemRoleController(ISystemRoleRepository systemRoleRepository)
    {
        _systemRoleRepository = systemRoleRepository;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetSystemRoles()
    {
        return Ok(await _systemRoleRepository.GetAllAsync());
    }
}