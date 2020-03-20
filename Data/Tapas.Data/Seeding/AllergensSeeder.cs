namespace Tapas.Data.Seeding
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    internal class AllergensSeeder : ISeeder
    {
        private const string AllergensPath = "./../Tapas.Web/wwwroot/Allergens/";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var allergensPaths = Directory.GetFiles(AllergensPath);

            foreach (var filePath in allergensPaths)
            {
                var allergenName = Path.GetFileNameWithoutExtension(filePath);
            }
        }
    }
}
 