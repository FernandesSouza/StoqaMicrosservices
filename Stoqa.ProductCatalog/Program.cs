using Stoqa.ProductCatalog.ApplicationService.Interfaces.ObserverContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.ApplicationService.RabbitMqService;
using Stoqa.ProductCatalog.ApplicationService.Services.ObserverNotification;
using Stoqa.ProductCatalog.ApplicationService.Services.ProductService;
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
builder.Services.AddScoped<IProductObserver, ProductSyncService>();
builder.Services.AddScoped<ProductNotifier>(sp =>
{
    var productSyncService = sp.GetRequiredService<ProductSyncService>();
    var notifier = new ProductNotifier();
    notifier.AddObserver(productSyncService);
    return notifier;
});


builder.Services.AddHttpClient<ProductSyncService>();


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