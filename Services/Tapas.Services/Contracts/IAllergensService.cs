using System.Threading.Tasks;

namespace Tapas.Services.Contracts
{
    public interface IAllergensService
    {
        bool IsAllergenExist(string allergenName);

        Task AddAsync(string allergenName, string path);
    }
}
