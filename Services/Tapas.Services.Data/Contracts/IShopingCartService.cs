namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Data.Models;
    using Tapas.Web.ViewModels.ShopingCart;

    public interface IShopingCartService
    {
        ShopingCartViewModel GetShopingCart(ApplicationUser user);

        AddItemViewModel GetShopingModel(string productId);

        Task AddItemAsync(AddItemViewModel model);

        Task DeleteItemAsync(int itemId, string shopingCartId);

        string GetDescription(int id);

        Task SetDescriptionAsync(int id, string message);
    }
}
