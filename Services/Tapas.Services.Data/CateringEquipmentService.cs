namespace Tapas.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Tapas.Common;
    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Contracts;
    using Tapas.Services.Data.Contracts;
    using Tapas.Services.Mapping;
    using Tapas.Web.ViewModels.Administration.CateringEquipment;

    public class CateringEquipmentService : ICateringEquipmentService
    {
        private readonly IDeletableEntityRepository<EquipmentForRent> equipmentRepository;
        private readonly ICloudService cloudService;

        public CateringEquipmentService(
            IDeletableEntityRepository<EquipmentForRent> equipmentRepository,
            ICloudService cloudService)
        {
            this.equipmentRepository = equipmentRepository;
            this.cloudService = cloudService;
        }

        public Task ActivateAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public async Task AddEquipmentAsync(CreateModel model)
        {
            var equipment = new EquipmentForRent()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
            };

            if (model.Image != null)
            {
                equipment.ImageUrl = await this.cloudService.UploadImageFromForm(model.Image);
            }

            await this.equipmentRepository.AddAsync(equipment);
            await this.equipmentRepository.SaveChangesAsync();
        }

        public CreateModel CreateInputModel()
        {
            return new CreateModel();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<IndexEquipmentModel> GetAll()
        {
            var model = this.equipmentRepository
                 .All()
                 .Select(x => new IndexEquipmentModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Description = x.Description,
                     Price = x.Price,
                     ImageUrl = x.ImageUrl,
                 })
                 .ToList();
            return model;
        }

        public object GetDeletedProducts()
        {
            throw new NotImplementedException();
        }

        public Details GetDetailsById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }

            var equipment = this.equipmentRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (equipment is null)
            {
                throw new Exception(string.Format(ExceptionMessages.NotExists, nameof(equipment)));
            }

            return new Details()
            {
                Id = equipment.Id,
                Name = equipment.Name,
                Description = equipment.Description,
                Price = equipment.Price,
                ImageUrl = equipment.ImageUrl,
            };
        }

        public object GetEditModel(string id)
        {
            throw new NotImplementedException();
        }

        public void SetEditModel(EditModel model)
        {
            throw new NotImplementedException();
        }
    }
}
