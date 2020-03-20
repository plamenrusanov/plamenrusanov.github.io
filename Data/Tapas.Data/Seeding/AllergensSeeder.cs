namespace Tapas.Data.Seeding
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Tapas.Services.Contracts;

    internal class AllergensSeeder : ISeeder
    {
        private const string AllergensPath = "./../Tapas.Web/wwwroot/Allergens/";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var allergensPaths = Directory.GetFiles(AllergensPath);
            var allergensService = serviceProvider.GetRequiredService<IAllergensService>();
            foreach (var filePath in allergensPaths)
            {
                var allergenName = Path.GetFileNameWithoutExtension(filePath);

                if (allergensService.IsAllergenExist(allergenName))
                {
                    continue;
                }

                await allergensService.AddAsync(allergenName, filePath);
            }
        }
    }
}
