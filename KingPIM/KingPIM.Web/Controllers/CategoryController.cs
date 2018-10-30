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
        private ICategoryRepository Repo;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            Repo = categoryRepository;
        }
        // Get all
        public IActionResult Index()
        {
            var categories = Repo.GetCategories();
            var vm = new CategoryViewModel
            {
                Categories = categories
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
        public IActionResult CreateCategory(CategoryViewModel vm)
        {
            Repo.CreateCategory(vm);
            
            return RedirectToAction("Index");
        }

        // Updates single Category
        public IActionResult UpdateCategory(CategoryViewModel categoryViewModel)
        {
            var category = Repo.Categories.FirstOrDefault(x => x.Id.Equals(categoryViewModel.CategoryId));

            if(ModelState.IsValid && categoryViewModel != null)
            {

                Repo.EditCategory(categoryViewModel);

            }

            return RedirectToAction("Index", categoryViewModel);
        }

        // Updates published value
        public IActionResult PublishCategory(CategoryViewModel categoryViewModel)
        {
            var category = Repo.Categories.FirstOrDefault(x => x.Id.Equals(categoryViewModel.CategoryId));
            
            if(ModelState.IsValid && categoryViewModel != null)
            {
                Repo.PublishCategory(categoryViewModel);
            }

            return RedirectToAction("Index");
        }

        // Deletes Category
        public IActionResult DeleteCategory(int categoryId)
        {
            var delete = Repo.DeleteCategory(categoryId);
            if(delete != null)
            {
                DeleteCategory(categoryId);
            }

            return RedirectToAction("Index");
        }
    }
}