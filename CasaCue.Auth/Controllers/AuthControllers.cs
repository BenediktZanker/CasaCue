using CasaCue.Services;
using CasaCue.Shared.Models;
using CasaCue.Shared.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CasaCue.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            var secret = config["Jwt:Secret"] ?? "fallback_secret_key";
            _jwtService = new JwtService(secret);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            Log.Information("Registering user: {Username}", user.Username);

            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            {
                Log.Warning("User already exists: {Username}", user.Username);
                return BadRequest(new { Message = "User already exists" });
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            Log.Information("User registered successfully: {Username}", user.Username);
            return Ok(new { Message = "User registered" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            Log.Information("Attempting login for user: {Username}", user.Username);

            var dbUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

            if (dbUser == null)
            {
                Log.Warning("Invalid login attempt: {Username}", user.Username);
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            var token = _jwtService.GenerateToken(user.Username);
            Log.Information("Token generated for user: {Username}", user.Username);

            return Ok(new { Token = token });
        }
        
        [HttpGet("protected")]
        [Authorize] // Stellt sicher, dass nur authentifizierte Benutzer Zugriff haben
        public IActionResult Protected()
        {
            Log.Information("Access to protected endpoint granted");
            return Ok(new { Message = "Protected endpoint accessed successfully" });
        }
        
        [HttpDelete("cleanup/{username}")]
        public async Task<IActionResult> CleanupUser(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(new { Message = $"User '{username}' deleted" });
            }

            return NotFound(new { Message = $"User '{username}' not found" });
        }
    }
}


