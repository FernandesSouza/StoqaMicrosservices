using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq.Consumers;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq.ObserverNotification;
using Stoqa.OrderCatalog.ApplicationService.Services.ProductSyncService;
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
builder.Services.AddScoped<ProductRegisterConsumer>();
builder.Services.AddHostedService<ProductRegisterConsumer>();
builder.Services.AddScoped<IProductObserver, ProductFactorySyncService>();
builder.Services.AddScoped<ProductNotification>(pn =>
{
    var factorySync = pn.GetRequiredService<IProductObserver>();
    var notification = new ProductNotification();
    notification.AddObserver(factorySync);

    return notification;
});


builder.Services.AddInversionOfControlHandler();

builder.WebHost.ConfigureKestrel(options => { options.ListenAnyIP(5000); });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
await app.MigrateDatabaseAsync();

app.Run();