namespace Tapas.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly IRepository<Setting> settingsRepository;

        public SettingsService(IRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.All().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }
    }
}
