using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TesteDotkon.Application.Interfaces;
using TesteDotkon.Application.Services;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.IoC;
using TesteDotkon.Infra.CrossCutting.NotificationPattern.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using TesteDotkon.Infra.CrossCutting.Security;
using TesteDotkon.Infra.CrossCutting.Swagger;
using TesteDotkon.Infra.Data.Context;
using TesteDotkon.Infra.MediatoR;
using TesteDotkon.Infra.Data.UoW;
using TesteDotkon.Domain.Commands.Usuario.Adicionar;
using FluentValidation;
using TesteDotkon.Infra.CrossCutting.Security.Autenticacao;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.SetupAuth(builder.Configuration);
builder.Services.SetupSwagger();
builder.Services.AddControllers();

builder.Services.AddDbContext<TesteDotkonContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DotkonConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddHttpContextAccessor();

var assemblies = AppDomain.CurrentDomain.GetAssemblies();

builder.Services.AddScoped<IUsuarioAppService, UsuarioAppService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsuarioAppService, UsuarioAppService>();
builder.Services.AddScoped<INotifiable, Notifiable>();
builder.Services.AddScoped<IUsuarioAutenticado, UsuarioAutenticado>();
builder.Services.AddValidatorsFromAssemblyContaining<UsuarioAdicionarValidator>();

builder.Services
    .SetupInject(assemblies)
    .AddMediator(assemblies);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSwagger();
app.UseHttpsRedirection();
app.UseCors();
app.UseRouting();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API TesteDotkon v1");
    c.RoutePrefix = string.Empty;
});

app.UseAuthorization();

app.Run();
