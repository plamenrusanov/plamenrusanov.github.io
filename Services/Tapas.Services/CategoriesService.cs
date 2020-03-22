namespace Tapas.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Contracts;
    using Tapas.Web.ViewModels.Administration.Categories;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task AddAsync(string name)
        {
            await this.categoriesRepository
                .AddAsync(new Category()
                {
                    Name = name,
                });
            await this.categoriesRepository.SaveChangesAsync();
        }

        public ICollection<CategoryViewModel> All()
        {
            return this.categoriesRepository.All().Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public async void Edit(CategoryViewModel categoryViewModel)
        {
            var category = this.categoriesRepository.All()
                .Where(x => x.Id == categoryViewModel.Id)
                .FirstOrDefault();

            category.Name = categoryViewModel.Name;
            await this.categoriesRepository.SaveChangesAsync();
        }

        public CategoryViewModel GetCategoryById(string categoryId)
        {
            return this.categoriesRepository.All()
                .Where(x => x.Id == categoryId)
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefault();
        }

        public bool IsCategoryExist(string name)
        {
            return this.categoriesRepository.All().Any(x => x.Name == name);
        }
    }
}
