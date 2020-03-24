namespace Tapas.Services.Data.Contracts
{
    using Tapas.Web.ViewModels.Administration.Products;

    public interface IProductsService
    {
        void AddAsync(ProductInputViewModel inputModel);
    }
}
