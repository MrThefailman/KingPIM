using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Models;
using KingPIM.Models.ViewModels;
using KingPIM.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // Get access to categoryRepo
        private ICategoryRepository categoryRepo;
        // Get access to subcategoryRepo
        private ISubcategoryRepository subcategoryRepo;
        public CategoryController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository)
        {
            categoryRepo = categoryRepository;
            subcategoryRepo = subcategoryRepository;
        }
        
        // Get all
        public IActionResult Index()
        {
            var categories = categoryRepo.GetCategories();
            var subcategories = subcategoryRepo.GetSubcategories();
            var vm = new MainPageViewModel
            {
                Categories = categories,
                Subcategories = subcategories
            };

            return View(vm);
        }

        // Will return single category
        public IActionResult GetCategory()
        {
            return View();
        }

        // Create new Category
        [HttpPost]
        public IActionResult CreateCategory(MainPageViewModel vm)
        {
            categoryRepo.CreateCategory(vm);
            
            return RedirectToAction("Index");
        }

        // Updates single Category
        public IActionResult UpdateCategory(MainPageViewModel vm)
        {
            var category = categoryRepo.Categories.FirstOrDefault(x => x.Id.Equals(vm.CategoryId));

            if(ModelState.IsValid && vm != null)
            {

                categoryRepo.EditCategory(vm);

            }

            return RedirectToAction("Index", vm);
        }

        // Updates published value
        public IActionResult PublishCategory(MainPageViewModel vm)
        {
            var category = categoryRepo.Categories.FirstOrDefault(x => x.Id.Equals(vm.CategoryId));
            
            if(ModelState.IsValid && vm != null)
            {
                categoryRepo.PublishCategory(vm);
            }

            return RedirectToAction("Index");
        }

        // Deletes Category
        public IActionResult DeleteCategory(int categoryId)
        {
            var delete = categoryRepo.DeleteCategory(categoryId);
            if(delete != null)
            {
                DeleteCategory(categoryId);
            }

            return RedirectToAction("Index");
        }
    }
}