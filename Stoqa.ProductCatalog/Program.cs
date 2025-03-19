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

   builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "DataBase_Conference";
    options.Configuration = "localhost:6379";
});

builder.Services.AddScoped<OrderConsumer>();
builder.Services.AddHostedService<OrderConsumer>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7000);
});

var app = builder.Build();


app.UseSwagger(); 
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
await app.MigrateDatabaseAsync();

app.Run();