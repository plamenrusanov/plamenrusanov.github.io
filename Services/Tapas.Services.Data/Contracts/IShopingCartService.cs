namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Data.Models;
    using Tapas.Web.ViewModels.ShopingCart;

    public interface IShopingCartService
    {
        ShopingCartViewModel GetShopingCart(ApplicationUser user);

        Task CreateShopingCartAsync(string userId);

        AddItemViewModel GetShopingModel(ApplicationUser user, string productId);

        void AddItem(AddItemViewModel model);

        void DeleteItem(int itemId, string shopingCartId);

        string GetDescription(int id);

        void SetDescription(int id, string message);
    }
}
