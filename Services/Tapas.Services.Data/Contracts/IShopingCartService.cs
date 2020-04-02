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
    }
}
