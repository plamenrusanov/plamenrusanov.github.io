namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Web.ViewModels.Administration.Categories;

    public interface ICategoriesService
    {
        bool IsCategoryExist(string name);

        Task AddAsync(string name);

        ICollection<CategoryViewModel> All();

        CategoryViewModel GetCategoryById(string categoryId);

        void Edit(CategoryViewModel categoryViewModel);
    }
}
