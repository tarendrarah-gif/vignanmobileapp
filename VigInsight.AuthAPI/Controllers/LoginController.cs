using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;

namespace VigInsight.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public LoginController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var validUser = await _userService.ValidateUserAsync(loginRequest.Username, loginRequest.Password);

                if (validUser == null)
                    return Unauthorized("Invalid credentials");

                string token;
                try
                {
                    token = GenerateJwtToken(validUser.Username);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Token generation failed: {ex.Message}");
                }

                // Return all user details needed by frontend
                return Ok(new
                {
                    Token = token,
                    Username = validUser.Username,
                    Role = validUser.Role,
                    UserId = validUser.UserId,
                    OrganizationId = validUser.OrganizationId,
                    OrganizationName = validUser.OrganizationName
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Login failed: {ex.Message}");
            }
        }

        private string GenerateJwtToken(string username)
        {
            try
            {
                var jwtKey = _config["Jwt:Key"];
                var jwtIssuer = _config["Jwt:Issuer"];

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var token = new JwtSecurityToken(
                    issuer: jwtIssuer,
                    audience: jwtIssuer,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating JWT token.", ex);
            }
        }
    }

}
