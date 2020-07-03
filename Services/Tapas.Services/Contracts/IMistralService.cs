namespace Tapas.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Services.Dto.Mistral;

    public interface IMistralService
    {
        Task<ICollection<LocationMDto>> Locations();

        Task<ICollection<ProductMDto>> GetAllData(int locationId, string search);

        Task<ICollection<StorageMDto>> Storages();

        Task SaveWebOrder(OrderMDto order);
    }
}
