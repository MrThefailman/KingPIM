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

        void CreateCategory(HomeViewModel vm);

        Category DeleteCategory(int categoryId);

        //Category EditCategory(int categoryId);

        void PublishCategory(Category category);
    }
}
