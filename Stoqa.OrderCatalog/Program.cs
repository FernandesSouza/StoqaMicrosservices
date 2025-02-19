using Stoqa.OrderCatalog.ApplicationService.RabbitMq;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq.Consumers;
using Stoqa.OrderCatalog.Ioc;
using Stoqa.OrderCatalog.Ioc.Settings;
using Stoqa.OrderCatalog.Ioc.Settings.Handlers;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSettingsControl(configuration);
builder.Services.AddSwaggerGen();
await builder.Services.RabbitFactory(configuration);
builder.Services.AddScoped<ProductConsumer>();
builder.Services.AddHostedService<ProductConsumer>();

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