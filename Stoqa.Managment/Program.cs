using Stoqa.Managment.IoC;
using Stoqa.Managment.IoC.Settings;
using Stoqa.Managment.IoC.Settings.Handlers;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddInversionOfControlHandler();
builder.Services.AddSettingsControl(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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