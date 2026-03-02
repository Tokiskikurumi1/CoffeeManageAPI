using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using AuthService.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity.Data;
using System.Data;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost("login")]
    public IActionResult Login(AuthService.Models.LoginRequest model)
    {
        using var con = new SqlConnection(_config.GetConnectionString("COFFEE"));
        con.Open();

        using var cmd = new SqlCommand("cf_login", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Username", model.Username);
        cmd.Parameters.AddWithValue("@PasswordHash", model.PasswordHash);

        using var rd = cmd.ExecuteReader();

        if (!rd.Read())
        {
            return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu" });
        }

        int userID = rd.GetInt32(rd.GetOrdinal("UserID"));
        string FullName = rd.GetString(rd.GetOrdinal("FullName"));
        string email = rd.GetString(rd.GetOrdinal("Email"));
        string phone = rd.GetString(rd.GetOrdinal("Phone"));
        string gender = rd.GetString(rd.GetOrdinal("Gender"));
        string address = rd.GetString(rd.GetOrdinal("Address"));
        string roleName = rd.GetString(rd.GetOrdinal("RoleName"));

        string token = GenerateToken(userID, FullName, email, roleName);

        return Ok(new
        {
            accessToken = token,
            role = roleName,
            user = FullName
        });
    }

    [HttpPost("register")]
    public IActionResult Register(AuthService.Models.RegisterRequest model)
    {
        using var con = new SqlConnection(_config.GetConnectionString("COFFEE"));
        con.Open();

        using var cmd = new SqlCommand("cf_register", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Username", model.Username);
        cmd.Parameters.AddWithValue("@PasswordHash", model.PasswordHash);
        cmd.Parameters.AddWithValue("@FullName", model.FullName);
        cmd.Parameters.AddWithValue("@Email", model.Email);

        using var rd = cmd.ExecuteReader();

        if (rd.Read())
        {
            int success = rd.GetInt32(rd.GetOrdinal("Success"));
            string message = rd.GetString(rd.GetOrdinal("Message"));

            if (success == 0)
                return BadRequest(new { message });

            return Ok(new { message });
        }

        return BadRequest(new { message = "Lỗi hệ thống" });
    }



    private string GenerateToken(int userId, string name, string email, string role)
    {
        var jwt = _config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("UserID", userId.ToString()),
            new Claim(ClaimTypes.Name, name),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(3),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

