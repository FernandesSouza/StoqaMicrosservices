using Stoqa.OrderCatalog.Ioc;
using Stoqa.OrderCatalog.Ioc.Settings;
using Stoqa.OrderCatalog.Ioc.Settings.Handlers;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSettingsControl(configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddInversionOfControlHandler();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
await app.MigrateDatabaseAsync();

app.Run();