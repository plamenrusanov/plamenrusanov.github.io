namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Web.ViewModels.Administration.Products;

    public interface IProductsService
    {
        Task AddAsync(ProductInputViewModel inputModel);

        MenuProductViewModel GetProductById(string productId);

        DetailsProductViewModel GetDetailsProductById(string productId);

        bool ExistProductById(string productId);

        EditProductViewModel GetEditProductById(string productId);

        Task EditProductAsync(EditProductViewModel model);

        DeleteProductViewModel GetDeleteProductById(string productId);

        Task DeleteProductAsync(string productId);

        ICollection<DetailsProductViewModel> GetAllProducts(bool isDeleted);

        void Activate(string productId);
    }
}
