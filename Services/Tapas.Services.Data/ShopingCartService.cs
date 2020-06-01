namespace Tapas.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Tapas.Common;
    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Allergens;
    using Tapas.Web.ViewModels.Administration.Products;
    using Tapas.Web.ViewModels.Administration.Sizes;
    using Tapas.Web.ViewModels.ShopingCart;
    using Tapas.Web.ViewModels.ShopingCartItems;

    public class ShopingCartService : IShopingCartService
    {
        private readonly IDeletableEntityRepository<ShopingCart> cartRepository;
        private readonly IDeletableEntityRepository<MenuProduct> productRepository;
        private readonly IDeletableEntityRepository<ProductSize> sizeRepository;
        private readonly IDeletableEntityRepository<ShopingCartItem> itemRepository;

        public ShopingCartService(
            IDeletableEntityRepository<ShopingCart> cartRepository,
            IDeletableEntityRepository<MenuProduct> productRepository,
            IDeletableEntityRepository<ProductSize> sizeRepository,
            IDeletableEntityRepository<ShopingCartItem> itemRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.sizeRepository = sizeRepository;
            this.itemRepository = itemRepository;
        }

        public void AddItem(AddItemViewModel model)
        {
            var cart = this.cartRepository
                .All()
                .Where(x => x.Id == model.ShopingCart.Id)
                .FirstOrDefault();

            var product = this.productRepository
                .All()
                .Where(x => x.Id == model.Product.Id)
                .FirstOrDefault();

            var size = this.sizeRepository.All()
                .Where(x => x.Id == model.Product.Sizes[0].SizeId)
                .FirstOrDefault();

            cart.CartItems.Add(new ShopingCartItem()
            {
                SizeId = size.Id,
                ProductId = product.Id,
                Quantity = model.Quantity,
                Description = model.Description,
            });
            this.cartRepository.SaveChanges();
        }

        public async Task CreateShopingCartAsync(string userId)
        {
            await this.cartRepository.AddAsync(new ShopingCart() { ApplicationUserId = userId });
            await this.cartRepository.SaveChangesAsync();
        }

        public void DeleteItem(int itemId, string shopingCartId)
        {
            var cart = this.cartRepository.All()
                .Where(x => x.Id == shopingCartId)
                .FirstOrDefault();

            var productCartItem = cart.CartItems
                .Where(x => x.Id == itemId)
                .FirstOrDefault();

            cart.CartItems.Remove(productCartItem);
            this.cartRepository.SaveChanges();
        }

        public string GetDescription(int id)
        {
            return this.itemRepository.All().Where(x => x.Id == id).FirstOrDefault().Description;
        }

        public ShopingCartViewModel GetShopingCart(ApplicationUser user)
        {
            var model = this.cartRepository.All()
                .Where(x => x.Id == user.ShopingCart.Id)
                .Select(x => new ShopingCartViewModel()
                {
                    Id = x.Id,
                    UserId = x.ApplicationUserId,
                    ShopingItems = x.CartItems.Select(c => new ShopingItemsViewModel()
                    {
                        Id = c.Id,
                        ProductId = c.ProductId,
                        ProductName = c.Product.Name,
                        ProductPrice = c.Size.Price,
                        Quantity = c.Quantity,
                    }).ToList(),
                    PackegesPrice = x.CartItems.Sum(c => Math.Ceiling((decimal)c.Quantity / c.Size.MaxProductsInPackage) * c.Size.Package.Price),
                }).FirstOrDefault();

            return model;
        }

        public AddItemViewModel GetShopingModel(ApplicationUser user, string productId)
        {
            return new AddItemViewModel()
            {
                Product = this.productRepository
                    .All()
                    .Where(x => x.Id == productId)
                    .Select(x => new DetailsProductAddItemVM()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        ImageUrl = x.ImageUrl != null ? x.ImageUrl : GlobalConstants.DefaultProductImage,
                        Allergens = x.Allergens
                            .Select(c => new DetailsAllergenViewModel()
                            {
                                Id = c.AllergenId,
                                Name = c.Allergen.Name,
                                ImageUrl = c.Allergen.ImageUrl,
                            }).ToList(),
                        Sizes = x.Sizes
                            .Select(c => new ProductSizeViewModel()
                            {
                                SizeId = c.Id,
                                SizeName = c.SizeName,
                                Price = c.Price,
                                Weight = c.Weight,
                                MaxProductsInPackage = c.MaxProductsInPackage,
                                PackagePrice = c.Package.Price,
                            }).ToList(),
                    }).FirstOrDefault(),
                ShopingCart = this.GetShopingCart(user),
            };
        }

        public void SetDescription(int id, string message)
        {
            var cartItem = this.itemRepository.All().Where(x => x.Id == id).FirstOrDefault();
            cartItem.Description = message;

            this.itemRepository.SaveChanges();
        }
    }
}
