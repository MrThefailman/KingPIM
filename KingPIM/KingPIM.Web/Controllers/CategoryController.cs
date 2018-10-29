using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPIM.Models;
using KingPIM.Models.ViewModels;
using KingPIM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPIM.Web.Controllers
{

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
            return View();
        }

        // Will return single category
        public IActionResult GetCategory()
        {
            return View();
        }

        // Create new Category
        [HttpPost]
        public IActionResult CreateCategory(HomeViewModel vm)
        {
            Repo.CreateCategory(vm);
            
            return RedirectToAction("Index", "Home");
        }

        // Updates single Category
        public IActionResult UpdateCategory()
        {
            return View();
        }

        // Updates published value
        public IActionResult PublishCategory(int categoryId)
        {
            //var publish = 


            return View();
        }

        // Deletes Category
        public IActionResult DeleteCategory(int categoryId)
        {
            var delete = Repo.DeleteCategory(categoryId);
            if(delete != null)
            {
                DeleteCategory(categoryId);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}