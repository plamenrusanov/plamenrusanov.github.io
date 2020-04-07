namespace Tapas.Services.Data
{
    using System.Linq;

    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Data.Models.Enums;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Addreses;
    using Tapas.Web.ViewModels.Orders;
    using Tapas.Web.ViewModels.ShopingCartItems;

    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> ordersRepository;
        private readonly IDeletableEntityRepository<ShopingCart> cartRepository;

        public OrdersService(IRepository<Order> ordersRepository, IDeletableEntityRepository<ShopingCart> cartRepository)
        {
            this.ordersRepository = ordersRepository;
            this.cartRepository = cartRepository;
        }

        public OrderInpitModel GetOrderViewModel(ApplicationUser user)
        {
            return new OrderInpitModel()
            {
                AddInfo = string.Empty,
                ApplicationUserId = user.Id,
                Status = OrderStatus.Unprocessed.ToString(),
                Addresses = user.Addresses
                    .Select(x => new AddressViewModel()
                    {
                        Id = x.Id,
                        AddInfo = x.AddInfo,
                        Street = x.Street,
                        StreetNumber = x.StreetNumber,
                    }).ToList(),
                CartItems = this.cartRepository
                    .All()
                    .Where(x => x.Id == user.ShopingCart.Id)
                    .FirstOrDefault()
                    .CartItems
                    .Select(x => new ShopingItemsViewModel()
                    {
                        Id = x.Id,
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name,
                        ProductPrice = x.Product.Price,
                        Quantity = x.Quantity,
                    }).ToList(),
            };
        }
    }
}
