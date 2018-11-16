using System.Text;
using KingPIM.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPIM.Web.Infrastructure
{
    public class ExportHelper
    {
        //public static List<MainPageViewModel> CategoryExportJSON(IEnumerable<Category> categories)
        //{
        //    //var catVmList = new List<MainPageViewModel>();

        //    //foreach(var cat in categories)
        //    //{
        //    //    catVmList.Add(
        //    //        new MainPageViewModel
        //    //        {
        //    //            Id = cat.Id,
        //    //            Name = cat.Name,
        //    //            Published = cat.Published,
        //    //            Subcategories = SubcategoryExportJSON(cat.Subcategories)
        //    //        });
        //    //}
        //    //return catVmList;
            
        //    return Json();

        //}

        public static List<CategoryExportViewModel> categories(IEnumerable<Category> categories)
        {
            var categoriesVm = new List<CategoryExportViewModel>();
            foreach(var cat in categories)
            {
                categoriesVm.Add(new CategoryExportViewModel
                {
                    Id = cat.Id,
                    Name = cat.Name,
                    Subcategories = cat.Subcategories,
                    AddedDate = cat.AddedDate,
                    UpdatedDate = cat.UpdatedDate,
                    Published = cat.Published,
                    Version = cat.Version
                });
            }
            return categoriesVm;
        }
       
        private static List<SubcategoryExportViewModel> SubcategoryExportJSON(List<Subcategory> subcategories)
        {
            var subcatVmList = new List<SubcategoryExportViewModel>();

            foreach(var subcat in subcategories)
            {
                subcatVmList.Add(
                    new SubcategoryExportViewModel
                    {
                        Id = subcat.Id,
                        Name = subcat.Name,
                        Published = subcat.Published
                    });
            }
            return subcatVmList;
        }
    }
}
