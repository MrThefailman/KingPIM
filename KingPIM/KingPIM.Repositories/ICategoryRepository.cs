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

        void CreateCategory(MainPageViewModel vm);

        Category DeleteCategory(int categoryId);

        void EditCategory(MainPageViewModel c);

        void PublishCategory(MainPageViewModel c);
    }
}
