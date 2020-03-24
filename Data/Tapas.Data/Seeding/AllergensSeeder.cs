namespace Tapas.Data.Seeding
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Tapas.Data.Models;

    public class AllergensSeeder : ISeeder
    {
        private const string AllergensPath = "./../Tapas.Web/wwwroot/Allergens/";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var allergensPaths = Directory.GetFiles(AllergensPath);

            foreach (var filePath in allergensPaths)
            {
                var allergenName = Path.GetFileNameWithoutExtension(filePath);

                if (dbContext.Allergens.Any(x => x.Name == allergenName))
                {
                    continue;
                }

                await dbContext.Allergens
                    .AddAsync(new Allergen()
                    {
                        Name = allergenName,
                        ImageUrl = filePath,
                    });
            }
        }
    }
}
