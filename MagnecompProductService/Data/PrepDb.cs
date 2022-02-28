using MagnecompProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace MagnecompProductService.Data
{
  public static class PrepDb
  {
    public static void PrepPopulation(IApplicationBuilder app, bool isProd)
    {
      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
      }
    }

    private static void SeedData(AppDbContext context, bool isProd)
    {
      if (isProd)
      {
        Console.WriteLine("--> Attempting to apply migrations...");
        try
        {
          context.Database.Migrate();
        }
        catch (Exception ex)
        {
          Console.WriteLine($"--> Could not run migrations: {ex.Message}");
        }
      }

      if (!context.Products.Any())
      {
        Console.WriteLine("--> Seeding Data...");

        context.Products.AddRange(
          new Product() { Name = "Dotnet", Publisher = "Microsoft", Cost = "Free" },
          new Product() { Name = "Java", Publisher = "Oracle", Cost = "Free" },
          new Product() { Name = "Golang", Publisher = "Google", Cost = "Free" }
        );

        context.SaveChanges();
      }
      else
      {
        Console.WriteLine("Skipping seeding database");
      }
    }
  }
}