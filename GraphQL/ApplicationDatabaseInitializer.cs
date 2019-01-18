using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphQL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoreGraphQL.GraphQL
{
    public class ApplicationDatabaseInitializer
    {
        public async Task SeedAsync(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                await applicationDbContext.Database.EnsureDeletedAsync();
                await applicationDbContext.Database.MigrateAsync();
                await applicationDbContext.Database.EnsureCreatedAsync();

                var items = new List<Item>(){
                    new Item { Barcode = "123", Title = "Headphone", SellingPrice= 50},
                    new Item { Barcode = "456", Title = "Keyboard", SellingPrice= 20},
                    new Item { Barcode = "789", Title = "Monitor", SellingPrice= 150}
                };

                await applicationDbContext.Items.AddRangeAsync(items);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}