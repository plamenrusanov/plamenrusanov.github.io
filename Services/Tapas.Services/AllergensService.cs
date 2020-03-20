namespace Tapas.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Contracts;

    public class AllergensService : IAllergensService
    {
        private readonly IRepository<Allergen> allergensRepository;

        public AllergensService(IRepository<Allergen> allergensRepository)
        {
            this.allergensRepository = allergensRepository;
        }

        public async Task AddAsync(string allergenName, string path)
        {
            var allergen = new Allergen()
            {
                Name = allergenName,
                ImageUrl = path,
            };

            await this.allergensRepository.AddAsync(allergen);
            await this.allergensRepository.SaveChangesAsync();
        }

        public bool IsAllergenExist(string allergenName)
        {
            return this.allergensRepository.All().Any(x => x.Name == allergenName);
        }
    }
}
