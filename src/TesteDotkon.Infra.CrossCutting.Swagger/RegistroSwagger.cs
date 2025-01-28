using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TesteDotkon.Infra.CrossCutting.Swagger;

public static class RegistroSwagger
{
    public static void SetupSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = """
                              <b>JWT Autorização</b> <br/> 
                                                    Digite 'Bearer' [espaço] e em seguida seu token na caixa de texto abaixo.
                                                    <br/> <br/>
                                                    <b>Exemplo:</b> 'bearer 123456abcdefg...'
                              """,
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "outh2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    }, new List<string>()
                }
            });
        });
    }
}
