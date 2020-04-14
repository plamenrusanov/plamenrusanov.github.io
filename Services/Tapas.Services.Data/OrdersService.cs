namespace Tapas.Services.Data
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task CreateAsync(ApplicationUser user, OrderInpitModel model)
        {
            var order = new Order()
            {
                AddInfo = model.AddInfo,
                AddressId = model.AddressId,
                UserId = user.Id,
                Status = OrderStatus.Unprocessed,
                CreatedOn = DateTime.UtcNow,
            };

            foreach (var item in user.ShopingCart.CartItems)
            {
                order.Bag.CartItems.Add(item);
            }

            user.ShopingCart.CartItems.Clear();

            await this.ordersRepository.AddAsync(order);
            await this.ordersRepository.SaveChangesAsync();
        }

        public OrderDetailsViewModel GetDetailsById(int id)
        {
            var order = this.ordersRepository.All().Where(x => x.Id == id).FirstOrDefault();

            return new OrderDetailsViewModel()
            {
                CreatedOn = order.CreatedOn.ToShortDateString(),
                Id = order.Id,
                DisplayAddress = order.Address.DisplayName,
                AddressInfo = order.Address.AddInfo,
                UserUserName = order.User.UserName,
                UserPhone = order.User.PhoneNumber,
                AddInfo = order.AddInfo,
                CartItems = order.Bag.CartItems
                    .Select(x => new ShopingItemsViewModel()
                    {
                        Id = x.Id,
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name,
                        ProductPrice = x.Product.Price,
                        Quantity = x.Quantity,
                    }).ToList(),
                Orders = this.GetLast50().Orders.ToList(),
                Status = order.Status,
                OrderStatus = this.Statuses(),
            };
        }

        public OrderDetailsViewModel GetLast50()
        {
            return new OrderDetailsViewModel()
            {
                Orders = this.ordersRepository.All()
                .OrderByDescending(x => x.Id)
                .Select(x => new OrdersViewModel()
                {
                    Id = x.Id,
                    AddInfo = x.AddInfo,
                    Address = new AddressViewModel()
                    {
                        AddInfo = x.Address.AddInfo,
                        DisplayName = x.Address.DisplayName,
                    },
                    ApplicationUserId = x.UserId,
                    Status = x.Status.ToString(),
                    CartItems = x.Bag.CartItems
                        .Select(c => new ShopingItemsViewModel()
                        {
                            Id = c.Id,
                            ProductId = c.Product.Id,
                            ProductName = c.Product.Name,
                            ProductPrice = c.Product.Price,
                            Quantity = c.Quantity,
                        }).ToList(),
                }).ToList(),
            };
        }

        public OrderInpitModel GetOrderInputModel(ApplicationUser user)
        {
            return new OrderInpitModel()
            {
                AddInfo = string.Empty,
                ApplicationUserId = user.Id,
                Addresses = user.Addresses
                    .Select(x => new AddressViewModel()
                    {
                        Id = x.Id,
                        AddInfo = x.AddInfo,
                        Street = x.Street,
                        StreetNumber = x.StreetNumber,
                        DisplayName = x.DisplayName,
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

        public bool IsExists(int id) => this.ordersRepository.All().Any(x => x.Id == id);

        public bool IsThereNew()
        {
            return this.ordersRepository.All().Any(x => x.Status == OrderStatus.Unprocessed);
        }

        private List<OrderStatus> Statuses()
        {
            return Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();
        }
    }
}
