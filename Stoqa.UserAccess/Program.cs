using Microsoft.AspNetCore.Identity;
using Stoqa.Identity.Domain.Entities;
using Stoqa.Identity.Infraestrutura.ORM;
using Stoqa.Identity.IoC;
using Stoqa.Identity.IoC.Container;
using Stoqa.Identity.IoC.Settings;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
//TODO: NÃO ESQUECER DE LIMPAR A PROGRAM
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();
builder.Services.AddCorsSettings();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.AddHttpClient();
builder.Services.AddSettingsControl(configuration);
builder.Services.AddInversionOfControlHandler();
builder.Services.AddGoogleAuthentication(configuration);

//FORÇO A PORTA PARA RODAR DOCKER
builder.WebHost.ConfigureKestrel(options => { options.ListenAnyIP(9000); });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors("AllowFrontend");
app.UseAuthorization();


app.MapControllers();
await app.MigrateDatabaseAsync();
app.Run();