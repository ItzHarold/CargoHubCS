using Backend.Features.Clients;
using Backend.Features.Contacts;
using Backend.Features.Inventories;
using Backend.Features.ItemGroups;
using Backend.Features.ItemLines;
using Backend.Features.Items;
using Backend.Features.ItemTypes;
using Backend.Features.Locations;
using Backend.Features.Orders;
using Backend.Features.Shipments;
using Backend.Features.Suppliers;
using Backend.Features.Transfers;

using Backend.Features.Warehouses;
using Backend.Infrastructure.Database;
using Backend.Infrastructure.Middleware;
using Microsoft.EntityFrameworkCore;

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
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<ITransferService, TransferService>();
        services.AddSingleton<ILocationService, LocationService>();
        services.AddSingleton<IItemService, ItemService>();
        services.AddSingleton<IInventoryService, InventoryService>();
        services.AddSingleton<IItemGroupService,ItemGroupService>();
        services.AddSingleton<IItemTypeService,ItemTypeService>();
        services.AddSingleton<IItemLineService,ItemLineService>();
        // services.AddSingleton<IOrderService,OrderService>();
        // services.AddSingleton<IShipmentService,ShipmentService>();
        services.AddSingleton<ISupplierService,SupplierService>();
    }
}
