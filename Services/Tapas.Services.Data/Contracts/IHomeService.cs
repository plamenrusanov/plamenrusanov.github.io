namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Home;

    public interface IHomeService
    {
        IEnumerable<CategoryWhitProductsViewModel> CategoryWhitProducts();
    }
}
