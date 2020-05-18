namespace Tapas.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
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

        public void Edit(CategoryViewModel categoryViewModel)
        {
            if (string.IsNullOrEmpty(categoryViewModel.Id))
            {
                throw new ArgumentNullException();
            }

            var category = this.categoriesRepository.All()
                .Where(x => x.Id == categoryViewModel.Id)
                .FirstOrDefault();

            if (category is null)
            {
                throw new Exception();
            }

            category.Name = categoryViewModel.Name;
            this.categoriesRepository.SaveChanges();
        }

        public CategoryViewModel GetCategoryViewModelById(string categoryId)
        {
            if (!this.ExistCategoryById(categoryId))
            {
                throw new ArgumentException();
            }

            return this.categoriesRepository.All()
                .Where(x => x.Id == categoryId)
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefault();
        }

        public bool ExistCategoryByName(string categoryName)
        {
            return this.categoriesRepository.All().Any(x => x.Name == categoryName);
        }

        public bool ExistCategoryById(string categoryId)
        {
            return this.categoriesRepository.All().Any(x => x.Id == categoryId);
        }

        public void Remove(string categoryId)
        {
            if (!this.ExistCategoryById(categoryId))
            {
                throw new ArgumentException();
            }

            var category = this.GetCategoryById(categoryId);

            this.categoriesRepository.Delete(category);
            this.categoriesRepository.SaveChanges();
        }

        public string GetCategoryNameById(string categoryId)
        {
            if (!this.ExistCategoryById(categoryId))
            {
                throw new ArgumentException();
            }

            return this.categoriesRepository.All()
                .Where(x => x.Id == categoryId)
                .Select(x => x.Name)
                .FirstOrDefault();
        }

        private Category GetCategoryById(string categoryId)
            => this.categoriesRepository.All().FirstOrDefault(x => x.Id == categoryId);
    }
}
