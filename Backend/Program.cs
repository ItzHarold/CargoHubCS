using Backend.Features.Clients;
using Backend.Infrastructure.Middleware;

namespace Backend;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddJsonFile("rolesConfig.json", optional: false, reloadOnChange: true);

        ConfigureServices(builder.Services);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseMiddleware<LoggingMiddleware>();
        app.UseMiddleware<ApiKeyMiddleware>();
        app.UseAuthorization();

        app.UseMiddleware<ApiKeyMiddleware>();

        app.MapControllers();

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddLogging();
        APIkeys-Middelware
        services.AddControllers(options =>
        {
            options.Filters.Add<GenericActionFilter>();
        });

        services.AddControllers();

        services.AddSingleton<IClientService, ClientService>();
    }
}
