using Backend.Features.Clients;
<<<<<<< Updated upstream
using Backend.Infrastructure.Filter;
=======
using Backend.Infrastructure.Middleware;
>>>>>>> Stashed changes

namespace Backend;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddLogging();
        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<GenericActionFilter>();
        });

        builder.Services.AddSingleton<IClientService, ClientService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

<<<<<<< Updated upstream
=======
        app.UseMiddleware<LoggingMiddleware>();
        app.UseMiddleware<ApiKeyMiddleware>();

>>>>>>> Stashed changes
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
<<<<<<< Updated upstream
=======
        services.AddAuthorization();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddLogging();
        services.AddControllers();
>>>>>>> Stashed changes

    }
}
