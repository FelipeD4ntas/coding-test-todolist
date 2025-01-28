using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TesteDotkon.Infra.CrossCutting.Security;

public static class ResgistroSecurity
{
    public static IServiceCollection SetupAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"] ?? "Dotkon",
                    ValidAudience = configuration["Jwt:Audience"] ?? "Dotkon",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "bWlLQW1wbGVNYXN0ZXJDcmVkZW50aWFsc0Zvckp3dEFQSS0="))
                };
            });

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}
