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
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Extras;

    public class ExtrasService : IExtrasService
    {
        private readonly IDeletableEntityRepository<Extras> extrasRepository;

        public ExtrasService(IDeletableEntityRepository<Extras> extrasRepository)
        {
            this.extrasRepository = extrasRepository;
        }

        public async Task Activate(int id)
        {
            var extras = this.CheckExistsReturnExtras(id);
            this.extrasRepository.Undelete(extras);
            await this.extrasRepository.SaveChangesAsync();
        }

        public ICollection<ExtraCartItemModel> All()
        {
            throw new NotImplementedException();
        }

        public Create Create()
        {
            return new Create();
        }

        public Task Create(Create model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var extras = this.CheckExistsReturnExtras(id);
            this.extrasRepository.Delete(extras);
            await this.extrasRepository.SaveChangesAsync();
        }

        public EditModel Edit(int id)
        {
            var extras = this.CheckExistsReturnExtras(id);

            return new EditModel()
            {
                Id = extras.Id,
                Name = extras.Name,
                Price = extras.Price,
                Weight = extras.Weight,
            };
        }

        public Task Edit(EditModel model)
        {
            throw new NotImplementedException();
        }

        private Extras CheckExistsReturnExtras(int id)
        {
            var extras = this.extrasRepository
                .AllWithDeleted()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (extras is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExists, nameof(extras)));
            }

            return extras;
        }
    }
}
