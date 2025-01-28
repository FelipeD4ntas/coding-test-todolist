using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoperCampos.SM.Infra.CrossCutting.Security.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TesteDotkon.Infra.CrossCutting.Security.Token;

public class TokenBuilder(IConfiguration configuration)
{
    private readonly string _jwtIssuer = configuration["Jwt:Issuer"] ?? "TestDotkon";
    private readonly string _jwtAudience = configuration["Jwt:Audience"] ?? "TestDotkon";
    private readonly string _jwtKey = configuration["Jwt:Key"] ?? "bWlLQW1wbGVNYXN0ZXJDcmVkZW50aWFsc0Zvckp3dEFQSS0=";

    private string _userId = string.Empty;
    private string _userName = string.Empty;
    private string _userEmail = string.Empty;

    public TokenBuilder WithUserId(string userId)
    {
        _userId = userId;
        return this;
    }

    public TokenBuilder WithUserName(string userName)
    {
        _userName = userName;
        return this;
    }

    public TokenBuilder WithUserEmail(string userEmail)
    {
        _userEmail = userEmail;
        return this;
    }

    public string Build()
    {
        var claims = new List<Claim>
        {
            new(CustomClaims.UserId, _userId),
            new(CustomClaims.UserName, _userName),
            new(CustomClaims.UserEmail, _userEmail),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtIssuer,
            audience: _jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
