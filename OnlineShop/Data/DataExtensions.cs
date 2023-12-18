using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication application)
    {
        var serviceProvide = application.Services;
        var scope = serviceProvide.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<OnlineShopContext>();
        dbContext.Database.Migrate();
    }
}
