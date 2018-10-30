using KingPIM.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        IEnumerable<Category> GetCategories();

        void CreateCategory(CategoryViewModel vm);

        Category DeleteCategory(int categoryId);

        void EditCategory(CategoryViewModel c);

        void PublishCategory(CategoryViewModel c);
    }
}
