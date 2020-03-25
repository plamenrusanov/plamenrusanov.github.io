namespace Tapas.Services.Data.Contracts
{
    using Tapas.Web.ViewModels.Home;

    public interface IHomeService
    {
        HomeIndexViewModel CategoryWhitProducts(string categoryId = null);
    }
}
