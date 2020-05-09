namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Web.ViewModels.Administration.CateringFood;

    public interface ICateringFoodService
    {
        CreateModel CreateInputModel();

        Task AddCateringFoodAsync(CreateModel model);

        List<IndexCateringFoodViewModel> GetAll();
    }
}
