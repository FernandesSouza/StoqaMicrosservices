namespace Stoqa.Identity.IoC.Settings;

public static class CorsSettings
{
    public static void AddCorsSettings(this IServiceCollection service) =>
        service.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                policy =>
                {
                    policy.WithOrigins("http://localhost:8585")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
}