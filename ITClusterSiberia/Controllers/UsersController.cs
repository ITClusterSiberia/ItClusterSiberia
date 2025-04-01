using Microsoft.AspNetCore.Mvc;
using YourNamespace.Data;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Здесь вы можете добавить дополнительную валидацию, например, проверку существующего email
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("A user with this email already exists!");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully!" });
        }
    }
}