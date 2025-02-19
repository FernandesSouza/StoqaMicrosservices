using Stoqa.ProductCatalog.ApplicationService.RabbitMqService;
using Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Consumers;
using Stoqa.ProductCatalog.Ioc;
using Stoqa.ProductCatalog.Ioc.Settings;
using Stoqa.ProductCatalog.Ioc.Settings.Handlers;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddInversionOfControlHandler();
builder.Services.AddSettingsControl(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
await builder.Services.RabbitFactory(configuration);
builder.Services.AddScoped<OrderConsumer>();
builder.Services.AddHostedService<OrderConsumer>();


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