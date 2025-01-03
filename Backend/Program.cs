using Backend.Features.Clients;
using Backend.Features.Warehouses;
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

        app.MapControllers();

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddLogging();
        services.AddControllers();

        services.AddSingleton<IClientService, ClientService>();
        services.AddSingleton<IWarehouseService, WarehouseService>();
    }
}
