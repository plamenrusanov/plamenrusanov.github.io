namespace Tapas.Services
{
    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Contracts;

    public class AllergensService : IAllergensService
    {
        public AllergensService(IDeletableEntityRepository<Allergen> settingsRepository)
        {

        }

        public bool IsAllergenExist(string allergenName)
        {
            throw new System.NotImplementedException();
        }
    }
}
