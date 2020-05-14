﻿namespace Tapas.Services.Data
{
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
        private readonly IDeletableEntityRepository<ShopingCartItem> itemsRepository;

        public OrdersService(
            IRepository<Order> ordersRepository,
            IDeletableEntityRepository<ShopingCart> cartRepository,
            IDeletableEntityRepository<ShopingCartItem> itemsRepository)
        {
            this.ordersRepository = ordersRepository;
            this.cartRepository = cartRepository;
            this.itemsRepository = itemsRepository;
        }

        public async Task<bool> ChangeStatusAsync(string status, string orderId, string setTime)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentNullException("OrderId is null.");
            }

            int id = default;
            if (int.TryParse(orderId, out id))
            {
                object statusResult = new object { };
                if (Enum.TryParse(typeof(OrderStatus), status, out statusResult))
                {
                    try
                    {
                        var order = this.ordersRepository.All().Where(x => x.Id == id).FirstOrDefault();
                        if (order is null)
                        {
                            throw new ArgumentException("Order is not exist.");
                        }

                        order.Status = (OrderStatus)statusResult;

                        int minutesToDelivery;
                        if (int.TryParse(setTime, out minutesToDelivery))
                        {
                            order.MinutesForDelivery = minutesToDelivery;
                        }

                        switch (statusResult)
                        {
                            case OrderStatus.Processed: order.ProcessingTime = DateTime.UtcNow; break;
                            case OrderStatus.OnDelivery: order.OnDeliveryTime = DateTime.UtcNow; break;
                            case OrderStatus.Delivered: order.DeliveredTime = DateTime.UtcNow; break;
                            default: break;
                        }

                        await this.ordersRepository.SaveChangesAsync();
                        return true;
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }

                throw new ArgumentException("Status is not valid.");
            }
            else
            {
                throw new ArgumentException("OrderId is not valid integer.");
            }
        }

        public async Task<int> CreateAsync(ApplicationUser user, OrderInpitModel model)
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
            return order.Id;
        }

        public OrderDetailsViewModel GetDetailsById(int id)
        {
            var order = this.ordersRepository.All().Where(x => x.Id == id).FirstOrDefault();

            return new OrderDetailsViewModel()
            {
                CreatedOn = order.CreatedOn.ToLocalTime().ToString("HH:mm:ss"),
                OrderId = order.Id,
                DisplayAddress = order.Address.DisplayName,
                AddressInfo = order.Address.AddInfo,
                UserUserName = order.User.UserName,
                UserPhone = order.User.PhoneNumber,
                AddInfo = order.AddInfo,
                CartItems = order.Bag.CartItems
                    .Select(x => new ShopingItemsViewModel()
                    {
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name,
                        ProductPrice = x.Size.Price,
                        Quantity = x.Quantity,
                    }).ToList(),
                Status = order.Status,
                OrderStatus = this.Statuses(),
            };
        }

        public ICollection<OrdersViewModel> GetDailyOrders()
        {
            return this.ordersRepository.All()
                .Where(x => x.CreatedOn.Date == DateTime.UtcNow.Date)
                .OrderByDescending(x => x.Id)
                .Select(x => new OrdersViewModel()
                {
                    Id = x.Id,
                    Status = x.Status.ToString(),
                }).ToList();
        }

        public OrderInpitModel GetOrderInputModel(ApplicationUser user)
        {
            if (user is null)
            {
                throw new ArgumentNullException();
            }

            var model = new OrderInpitModel()
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
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name,
                        ProductPrice = x.Size.Price,
                        Quantity = x.Quantity,
                    }).ToList(),
                PackegesPrice = this.itemsRepository
                    .All()
                    .Where(x => x.ShopingCartId == user.ShopingCart.Id)
                    .Sum(x => Math.Ceiling((decimal)x.Quantity / x.Size.MaxProductsInPackage) * x.Size.Package.Price),
            };

            model.OrderPrice = model.CartItems.Sum(x => x.ItemPrice) + model.PackegesPrice + model.DeliveryFee;

            return model;
        }

        public OrderDetailsViewModel GetUpdate()
        {
            return this.ordersRepository.All()
                .Where(x => x.Status == OrderStatus.Unprocessed)
                .Select(x => new OrderDetailsViewModel()
                {
                    AddInfo = x.AddInfo,
                    AddressInfo = x.Address.AddInfo,
                    CartItems = x.Bag.CartItems.Select(c => new ShopingItemsViewModel()
                    {
                        ProductName = c.Product.Name,
                        Quantity = c.Quantity,
                    }).ToList(),
                    CreatedOn = x.CreatedOn.ToLocalTime().ToString("HH:mm:ss"),
                    DisplayAddress = x.Address.DisplayName,
                    OrderId = x.Id,
                    Status = x.Status,
                    UserPhone = x.User.PhoneNumber,
                    UserUserName = x.User.UserName,
                    OrderStatus = this.Statuses(),
                }).FirstOrDefault();
        }

        public bool IsExists(int id) => this.ordersRepository.All().Any(x => x.Id == id);

        public bool IsThereNew()
        {
            return this.ordersRepository.All().Any(x => x.Status == OrderStatus.Unprocessed);
        }

        public ICollection<OrderCollectionViewModel> GetAll()
        {
            return this.ordersRepository.All()
                .Select(x => new OrderCollectionViewModel()
                {
                    Id = x.Id,
                    UserName = x.User.UserName,
                    DateTime = x.CreatedOn.ToLocalTime(),
                }).OrderByDescending(x => x.Id).ToList();
        }

        public ICollection<OrdersViewModel> GetOrdersByUserName(string userName)
        {
            return this.ordersRepository.All()
                .Where(x => x.User.UserName == userName)
                .Select(x => new OrdersViewModel()
                {
                    Id = x.Id,
                    Status = x.Status.ToString(),
                }).OrderByDescending(x => x.Id).ToList();
        }

        public UserOrderViewModel GetMyActiveOrder(ApplicationUser user)
        {
            if (user is null)
            {
                throw new ArgumentNullException("User is null!");
            }

            var order = this.ordersRepository.All()
                .Where(x => x.UserId == user.Id && x.Status != OrderStatus.Delivered)
                .FirstOrDefault();
            if (order is null)
            {
                return null;
            }

            return new UserOrderViewModel()
            {
                OrderId = order.Id,
                Status = order.Status.ToString(),
                ArriveTime = order.CreatedOn.ToLocalTime().AddMinutes((double)order.MinutesForDelivery).ToString("HH:mm:ss"),
            };
        }

        private List<OrderStatus> Statuses()
        {
            return Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();
        }

    }
}
