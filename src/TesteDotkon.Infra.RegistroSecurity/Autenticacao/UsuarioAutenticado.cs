using System.IdentityModel.Tokens.Jwt;
using CoperCampos.SM.Infra.CrossCutting.Security.Token;
using Microsoft.AspNetCore.Http;

namespace TesteDotkon.Infra.CrossCutting.Security.Autenticacao;

public class UsuarioAutenticado(IHttpContextAccessor accessor) : IUsuarioAutenticado
{
    public Guid UsuarioId => Guid.Parse(ObterClaim(CustomClaims.UserId) ?? "00000000-0000-0000-0000-000000000000");
    public string UsuarioNome => ObterClaim(CustomClaims.UserName) ?? "Falha ao Recuperar o Nome do Usuário";
    public string UsuarioEmail => ObterClaim(CustomClaims.UserEmail) ?? "Falha ao Recuperar o Email do Usuário";
    public DateTime Expiracao => ObterDataExpiracao();

    private string? ObterClaim(string claimType)
    {
        var claim = accessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == claimType);
        return claim?.Value;
    }

    private DateTime ObterDataExpiracao()
    {
        var expClaim = ObterClaim(JwtRegisteredClaimNames.Exp);
        if (expClaim == null)
            return DateTime.MinValue;

        return long.TryParse(expClaim, out var exp) ? DateTimeOffset.FromUnixTimeSeconds(exp).UtcDateTime : DateTime.MinValue;
    }
}