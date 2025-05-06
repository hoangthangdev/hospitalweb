using BuildingCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

        var configuration = builder.Build();
        var connectionString = configuration.GetConnectionString("Database");
        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("Connection string not found in appsettings.json.");
            return;
        }
        else
        {
            Console.WriteLine($"Connection string found: {connectionString}");
        }
        var services = new ServiceCollection();
        services.AddDbContext<HospitalDbContext>(options =>
            options.UseSqlServer(connectionString));

        var serviceProvider = services.BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();

        Console.WriteLine("Applying Migrations...");
        context.Database.Migrate();
        Console.WriteLine("Done.");
    }
}