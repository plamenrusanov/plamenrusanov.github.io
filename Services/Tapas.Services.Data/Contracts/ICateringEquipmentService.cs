namespace Tapas.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Tapas.Web.ViewModels.Administration.CateringEquipment;

    public interface ICateringEquipmentService
    {
        List<IndexEquipmentModel> GetAll();

        Task ActivateAsync(string productId);

        object GetDeletedProducts();

        Task Delete(string id);

        void SetEditModel(EditModel model);

        object GetEditModel(string id);

        Details GetDetailsById(string id);

        Task AddEquipmentAsync(CreateModel model);

        CreateModel CreateInputModel();
    }
}
