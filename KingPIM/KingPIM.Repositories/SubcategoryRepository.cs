using KingPIM.Data;
using KingPIM.Models;
using KingPIM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPIM.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private ApplicationDbContext ctx;
        public SubcategoryRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        // Reads all subcategories
        public IEnumerable<Subcategory> Subcategories => ctx.Subcategories;
        public IEnumerable<Subcategory> GetSubcategories()
        {
            return Subcategories;
        }

        // Add subcategory to DB
        public void CreateSubcategory(MainPageViewModel vm)
        {
            if(vm.Id == 0)
            {
                var newSubcat = new Subcategory
                {
                    Name = vm.Name,
                    SubcategoryAttributeGroups = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1,
                    CategoryId = vm.CategoryId
                };
                ctx.Subcategories.Add(newSubcat);
            }
            ctx.SaveChanges();
        }

        // Deletes subcategory from DB
        public Subcategory DeleteSubcategory(int subcategoryId)
        {
            var ctxSubcategory = ctx.Subcategories.FirstOrDefault(x => x.Id.Equals(subcategoryId));
            if(ctxSubcategory != null)
            {
                ctx.Subcategories.Remove(ctxSubcategory);
                ctx.SaveChanges();
            }
            return ctxSubcategory;
        }

        // Publish subcategory
        public void PublishSubcategory(MainPageViewModel s)
        {
            var ctxSubcategory = ctx.Subcategories.FirstOrDefault(x => x.Id.Equals(s.SubcategoryId));
            
            if(ctxSubcategory != null)
            {
                var ctxCategory = ctx.Categories.FirstOrDefault(x => x.Id.Equals(ctxSubcategory.CategoryId));
                var Category = Subcategories.Where(x => x.CategoryId == ctxCategory.Id);
                if (!ctxSubcategory.Published)
                {
                    ctxSubcategory.Published = true;
                    ctxCategory.Published = true;
                }
                else
                {
                    ctxSubcategory.Published = false;
                    if (Category.Count(x => x.Published) == 0)
                    {
                        ctxCategory.Published = false;
                    }
                }
            }
            ctx.SaveChanges();
        }

        // Edit subcategory
        public void EditSubcategory(MainPageViewModel s)
        {
            var ctxSubcategory = ctx.Subcategories.FirstOrDefault(x => x.Id.Equals(s.SubcategoryId));

            if(ctxSubcategory != null)
            {
                if(s.Name != ctxSubcategory.Name && s.Name != null)
                {
                    ctxSubcategory.Name = s.Name;
                }
                ctxSubcategory.UpdatedDate = DateTime.Now;
                ctxSubcategory.Version++;
                if(s.CategoryId != 0)
                {
                    ctxSubcategory.CategoryId = s.CategoryId;
                }
            }
            ctx.SaveChanges();
        }
    }
}
