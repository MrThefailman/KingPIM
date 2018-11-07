using KingPIM.Data;
using KingPIM.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPIM.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private ApplicationDbContext ctx;
        public CategoryRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        // Reads all categories
        public IEnumerable<Category> Categories => ctx.Categories;
        public IEnumerable<Category> GetCategories()
        {
            return Categories;
        }

        // Add category to DB
        public void CreateCategory(MainPageViewModel vm)
        {
            //var ctxCategories = ctx.Categories;

            if(vm.Id == 0)
            {
                var newCat = new Category
                {
                    Name = vm.Name,
                    Subcategories = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1
                };
                ctx.Categories.Add(newCat);
            }
            ctx.SaveChanges();
        }

        // Delete Category from DB
        public Category DeleteCategory(int categoryId)
        {
            // Patrik, DRY?
            var ctxCategory = ctx.Categories.FirstOrDefault(x => x.Id.Equals(categoryId));
            if(ctxCategory != null)
            {
                ctx.Categories.Remove(ctxCategory);
                ctx.SaveChanges();
            }
            return ctxCategory;
        }

        // Publishes category
        public void PublishCategory(MainPageViewModel c)
        {
            // Patrik, DRY?
            var ctxCategory = ctx.Categories.FirstOrDefault(x => x.Id.Equals(c.CategoryId));

            if(ctxCategory != null)
            {
                if (!ctxCategory.Published)
                {
                    ctxCategory.Published = true;
                }
                else
                {
                    ctxCategory.Published = false;
                }
                
            }
            ctx.SaveChanges();
            
        }

        // Edit category
        public void EditCategory(MainPageViewModel c)
        {
            var ctxCategory = ctx.Categories.FirstOrDefault(x => x.Id.Equals(c.CategoryId));

            if(ctxCategory != null)
            {
                if(c.Name != ctxCategory.Name && c.Name != null)
                {
                    ctxCategory.Name = c.Name;
                }
                ctxCategory.UpdatedDate = DateTime.Now;
                ctxCategory.Version++;
            }
            ctx.SaveChanges();
        }

    }
}
