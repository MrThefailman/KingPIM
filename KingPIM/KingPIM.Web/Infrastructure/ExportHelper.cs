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
        public static List<CategoryExportViewModel> GetCategories(IEnumerable<Category> categories)
        {
            var categoriesVm = new List<CategoryExportViewModel>();
            foreach (var cat in categories)
            {
                categoriesVm.Add(new CategoryExportViewModel
                {
                    Id = cat.Id,
                    Name = cat.Name,
                    Subcategories = ConvertSubcat(cat.Subcategories),
                    AddedDate = cat.AddedDate,
                    UpdatedDate = cat.UpdatedDate,
                    Published = cat.Published,
                    Version = cat.Version
                });
            }
            return categoriesVm;
        }

        private static List<SubcategoryExportViewModel> ConvertSubcat(List<Subcategory> subcategories)
        {
            var subcatList = new List<SubcategoryExportViewModel>();

            foreach (var subcat in subcategories)
            {
                subcatList.Add(
                    new SubcategoryExportViewModel
                    {
                        Id = subcat.Id,
                        Name = subcat.Name,
                        CategoryId = subcat.CategoryId,
                        AddedDate = subcat.AddedDate,
                        UpdatedDate = subcat.UpdatedDate,
                        Published = subcat.Published,
                        Version = subcat.Version
                    });
            }
            return subcatList;
        }

        public static List<SubcategoryExportViewModel> GetSubcategories(IEnumerable<Subcategory> subcategories)
        {
            var subcategoriesVm = new List<SubcategoryExportViewModel>();
            foreach (var subcat in subcategories)
            {
                subcategoriesVm.Add(
                    new SubcategoryExportViewModel
                    {
                        Id = subcat.Id,
                        Name = subcat.Name,
                        CategoryId = subcat.CategoryId,
                        Products = ConvertProduct(subcat.Products),
                        AddedDate = subcat.AddedDate,
                        UpdatedDate = subcat.UpdatedDate,
                        Published = subcat.Published,
                        Version = subcat.Version
                    });
            }
            return subcategoriesVm;
        }

        private static List<ProductExportViewModel> ConvertProduct(List<Product> products)
        {
            var productList = new List<ProductExportViewModel>();
            foreach (var prod in products)
            {
                productList.Add(
                    new ProductExportViewModel
                    {
                        Id = prod.Id,
                        Name = prod.Name,
                        Price = prod.Price,
                        Description = prod.Description,
                        AddedDate = prod.AddedDate,
                        UpdatedDate = prod.UpdatedDate,
                        Version = prod.Version,
                        Published = prod.Published
                    });
            }
            return productList;
        }

        public static List<ProductExportViewModel> GetProducts(IEnumerable<Product> products)
        {
            var productVm = new List<ProductExportViewModel>();
            foreach(var prod in products)
            {
                productVm.Add(
                    new ProductExportViewModel
                    {
                        Id = prod.Id,
                        Name = prod.Name,
                        SubcategoryId = prod.SubcategoryId,
                        Price = prod.Price,
                        Description = prod.Description,
                        AddedDate = prod.AddedDate,
                        UpdatedDate = prod.UpdatedDate,
                        Version = prod.Version,
                        Published = prod.Published
                    });
            }
            return productVm;
        }
    }
}
