using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("-->Seeding data.");

                context.Platforms.AddRange(
                    new Platform() {Name="Dotnet", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="Sql Server", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="Kubernetes", Publisher="CNCF", Cost="Free"}
                );

                context.SaveChanges();         
            }
            else
            {
                Console.WriteLine("-->We already have data.");
            }
        }
    }
}