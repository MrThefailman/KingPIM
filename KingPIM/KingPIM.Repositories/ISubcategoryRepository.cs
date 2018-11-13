using KingPIM.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Repositories
{
    public interface ISubcategoryRepository
    {
        IEnumerable<Subcategory> Subcategories { get; }
        IEnumerable<Subcategory> GetSubcategories();

        int CreateSubcategory(MainPageViewModel vm);

        Subcategory DeleteSubcategory(int subcategoryId);

        void EditSubcategory(MainPageViewModel s);

        void PublishSubcategory(MainPageViewModel s);
    }
}
