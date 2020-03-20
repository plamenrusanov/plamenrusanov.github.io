namespace Tapas.Services.Contracts
{
    using System.Threading.Tasks;

    public interface IAllergensService
    {
        bool IsAllergenExist(string allergenName);

        Task AddAsync(string allergenName, string path);
    }
}
